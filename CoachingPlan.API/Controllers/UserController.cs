using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.AddressCommands;
using CoachingPlan.Domain.Commands.CoachCommands;
using CoachingPlan.Domain.Commands.CoacheeCommands;
using CoachingPlan.Domain.Commands.PersonCommands;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IUserApplicationService _service;
        private readonly IPersonApplicationService _servicePerson;
        private readonly ICoachApplicationService _serviceCoach;
        private readonly ICoacheeApplicationService _serviceCoachee;

        //public UserController(){}
        public UserController(IUserApplicationService service, IPersonApplicationService servicePerson, ICoachApplicationService serviceCoach, ICoacheeApplicationService serviceCoachee)
        {
            this._service = service;
            this._serviceCoach = serviceCoach;
            this._serviceCoachee = serviceCoachee;
            this._servicePerson = servicePerson;
        }

        [HttpGet]
        [Route("api/users")]
        public Task<HttpResponseMessage> Get()
        {
            var users = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, users);
        }


        [HttpPost]
        [Route("api/users")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            List<Address> listAddress = new List<Address>();
            foreach (var item in body.address)
            {
                if ((item.city != null) || (item.city != ""))
                {
                    listAddress.Add(new Address(
                        (string)item.cep,
                        (EStates)item.state,
                        (string)item.city,
                        (string)item.street,
                        (int)item.number,
                        (EAddressType)item.type,
                        (string)item.description
                        ));
                }
            }

            List<Phone> listPhone = new List<Phone>();
            foreach (var item in body.phone)
            {
                if ((item.number != null) || (item.number != ""))
                {
                    listPhone.Add(new Phone(
                        (string)item.ddd,
                        (string)item.number,
                        (string)item.description
                        ));
                }
            }

            var commandPerson = new CreatePersonCommand(
                name: (string)body.name,
                cpf: (string)body.cpf,
                birthDate: (DateTime)body.birthDate,
                genre: (EGenre)body.genre,
                status: (bool)body.status,
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

            if (commandUser.Type == ETypeUser.Coach)
            {
                var commandCoach = new CreateCoachCommand(
                    idUser: user.Id,
                    evaluationTool: (List<EvaluationTool>)body.evaluationTool,
                    formation: (List<Formation>)body.formation,
                    speciality: (List<Speciality>)body.speciality,
                    coachingProcess: (List<CoachingProcess>)body.coachingProcess);

                _serviceCoach.Create(commandCoach);
            }
            else if (commandUser.Type == ETypeUser.Coachee)
            {
                var commandCoachee = new CreateCoacheeCommand(
                    profession: (string)body.profesion,
                    idUser: user.Id,
                    filledTool: (List<FilledTool>)body.filledTool,
                    strongPoint: (List<StrongPoint>)body.formation,
                    weakness: (List<Weakness>)body.speciality,
                    coachingProcess: (List<CoachingProcess>)body.coachingProcess);

                _serviceCoachee.Create(commandCoachee);
            }

            return CreateResponse(HttpStatusCode.Created, user);
        }
    }
}