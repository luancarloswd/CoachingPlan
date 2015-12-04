using CoachingPlan.API.Controllers;
using CoachingPlan.API.ViewModels;
using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Administrator, Coach, Coachee, SessionManager")]
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;
        private readonly IRoleApplicationService _serviceRole;
        private readonly IPersonApplicationService _servicePerson;
        private readonly IAddressApplicationService _serviceAddress;
        private readonly IPhoneApplicationService _servicePhone;

        public UserController(IUserApplicationService service, IPersonApplicationService servicePerson, IRoleApplicationService serviceRole, IAddressApplicationService serviceAddress, IPhoneApplicationService servicePhone)
        {
            this._service = service;
            this._servicePerson = servicePerson;
            this._serviceRole = serviceRole;
            this._serviceAddress = serviceAddress;
            this._servicePhone = servicePhone;
        }

        [HttpGet]
        [Route("api/users")]
        public Task<HttpResponseMessage> Get()
        {
            var users = _service.GetAllIncludeDetails();
            List<UserRoleViewModel> listUsersRoles = new List<UserRoleViewModel>();
            foreach (var user in users)
            {
                var roles = _service.GetAllRoles(user.Id);
                listUsersRoles.Add(new UserRoleViewModel(user, roles));
            }
            return CreateResponse(HttpStatusCode.OK, listUsersRoles);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/users/generateTokenRecoveryPassword")]
        public Task<HttpResponseMessage> GenerateTokenRecoveryPassword([FromBody]dynamic body)
        {
            var user = _service.GetOneByEmail((string)body.headers.email);
            if (user != null)
            {
                var token = _service.GenerateTokenRecoveryPassword(user.Email);
                _service.SendEmailRecoveryPassword(user.Id, token);
                return CreateResponse(HttpStatusCode.OK, user);
            }
            else return CreateResponse(HttpStatusCode.NotFound, user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/users/recoveryPassword/")]
        public Task<HttpResponseMessage> RecoveryPassword([FromBody]dynamic body)
        {
            var user = _service.GetOne((string)body.headers.idUser);
            if (user != null)
            {
                _service.RecoveryPassword(user.Id, (string)body.headers.token, (string)body.headers.password);
                return CreateResponse(HttpStatusCode.OK, user);
            }
            else return CreateResponse(HttpStatusCode.NotFound, user);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var user = _service.GetOneIncludeDetails(id);
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var cpf = _servicePerson.GetOneByCPF((string)body.cpf);

            if (cpf != null)
                return CreateResponse(HttpStatusCode.Ambiguous, cpf);

            var email = _service.GetOneByEmail((string)body.email);

            if (email != null)
                return CreateResponse(HttpStatusCode.Ambiguous, cpf);

            var listAddress = _serviceAddress.AddToPerson(body.address);

            var listPhone = _servicePhone.AddToPerson(body.phone);

            var commandPerson = new CreatePersonCommand(
               name: (string)body.name,
               cpf: (string)body.cpf,
               birthDate: (DateTime)body.birthDate,
               genre: (EGenre)body.genre,
               address: listAddress,
               phone: listPhone,
               phototgraph: (string)body.photograph
               );

            var person = _servicePerson.Create(commandPerson);

            var commandUser = new CreateUserCommand(
                email: (string)body.email,
                password: (string)body.password,
                userName: (string)body.email,
                idPerson: person.Id,
                type: (ETypeUser)body.type
            );

            var user = _service.Create(commandUser);

            if (commandUser.Type == ETypeUser.Administrator)
                _service.AddRole(user.Id, "Administrator");
            else if (commandUser.Type == ETypeUser.SessionManager)
                _service.AddRole(user.Id, "SessionManager");

            var token = _service.GenerateTokenRecoveryPassword(user.Email);
            _service.SendEmailRecoveryPassword(user.Id, token);

            return CreateResponse(HttpStatusCode.Created, user);
        }


        [HttpPut]
        [Route("api/users")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var listAddress = _serviceAddress.AddToPerson(body.person.address);

            var listPhone = _servicePhone.AddToPerson(body.person.phone);

            var commandPerson = new UpdatePersonCommand(
                id: Guid.Parse((string)body.person.id),
               name: (string)body.person.name,
               birthDate: (DateTime)body.person.birthDate,
               genre: (EGenre)body.person.genre,
               address: listAddress,
               phone: listPhone,
               phototgraph: (string)body.person.photograph
               );

            var person = _servicePerson.Update(commandPerson);

            _serviceAddress.CheckAddressRemoved(listAddress, person.Id);

            _servicePhone.CheckPhoneRemoved(listPhone, person.Id);

            var commandUser = new UpdateUserCommand(
                id: (string)body.id,
                password: (string)body.password,
                userName: (string)body.email,
                idPerson: person.Id
            );

            var user = _service.Update(commandUser);

            return CreateResponse(HttpStatusCode.Created, user);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {

            var user =  _service.Delete(id);
            return CreateResponse(HttpStatusCode.OK, user);
        }
    }
}