using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ServiceController : BaseController
    {
        private readonly IServiceApplicationService _service;

        public ServiceController(IServiceApplicationService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/services")]
        public Task<HttpResponseMessage> Get()
        {
            var services = _service.GetAll();
            return CreateResponse(HttpStatusCode.OK, services);
        }

        [HttpGet]
        [Route("api/services/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var Service = _service.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, Service);
        }

        [HttpGet]
        [Route("api/services/coachingProcess/{id}")]
        public Task<HttpResponseMessage> GetByCoachingProcess(string id)
        {
            var Service = _service.GetAllByCoachingProcess(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, Service);
        }

        [HttpPost]
        [Route("api/services")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var commandService = new CreateServiceCommand(
                   name: (string)body.name,
                   value: (float)body.value,
                   description: (string)body.description
               );

            var service = _service.Create(commandService);

            return CreateResponse(HttpStatusCode.Created, service);
        }


        [HttpPut]
        [Route("api/Services")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var commandService = new UpdateServiceCommand(
                  id: Guid.Parse((string)body.id),
                  name: (string)body.name,
                  value: (float)body.value,
                  description: (string)body.description
              );

            var service = _service.Update(commandService);

            return CreateResponse(HttpStatusCode.Created, service);
        }

        [HttpDelete]
        [Route("api/Services/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var Service = _service.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, Service);
        }
    }
}