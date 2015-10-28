using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.MessageCommands;
using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Coach, Coachee")]
    public class MessageController : BaseController
    {
        private readonly IMessageApplicationService _serviceMessage;

        public MessageController(IMessageApplicationService serviceMessage)
        {
            this._serviceMessage = serviceMessage;
        }

        [HttpGet]
        [Route("api/messages/{idUser}/{destination}")]
        public Task<HttpResponseMessage> Get(string idUser, string destination)
        {
            var message = _serviceMessage.GetHistoryMessages(idUser, destination);
            return CreateResponse(HttpStatusCode.OK, message);
        }

        [HttpPost]
        [Route("api/messages")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var commandMessage = new CreateMessageCommand(
                   bodyMessage: (string)body.bodyMessage,
                   destination: (string)body.destination,
                   date: DateTime.Now,
                   idUser: (string)body.idUser
               );

            var message = _serviceMessage.Create(commandMessage);

            return CreateResponse(HttpStatusCode.Created, message);
        }
        [HttpGet]
        [Route("api/message/{id}")]
        public Task<HttpResponseMessage> Read(string id)
        {
            var message = _serviceMessage.Read(Guid.Parse((string)id));

            return CreateResponse(HttpStatusCode.Created, message);
        }
    }
}