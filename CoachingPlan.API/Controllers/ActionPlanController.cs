using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.ActionPlanCommands;
using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Administrator, Coach")]
    public class ActionPlanController : BaseController
    {
        private readonly IActionPlanApplicationService _serviceActionPlan;
        private readonly IObjectiveApplicationService _serviceObjective;
        private readonly IMarkApplicationService _serviceMark;
        private readonly IJobApplicationService _serviceJob;
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;

        public ActionPlanController(IActionPlanApplicationService serviceActionPlan,
            IObjectiveApplicationService serviceObjective,
            IMarkApplicationService serviceMark,
            IJobApplicationService serviceJob,
            ICoachingProcessApplicationService serviceCoachingProcess)
        {
            this._serviceActionPlan = serviceActionPlan;
            this._serviceObjective = serviceObjective;
            this._serviceMark = serviceMark;
            this._serviceJob = serviceJob;
            this._serviceCoachingProcess = serviceCoachingProcess;
        }

        [HttpGet]
        [Route("api/actionPlan")]
        public Task<HttpResponseMessage> Get()
        {
            var actionPlan = _serviceActionPlan.GetAll();
            return CreateResponse(HttpStatusCode.OK, actionPlan);
        }

        [HttpGet]
        [Route("api/actionPlan/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var ActionPlan = _serviceActionPlan.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, ActionPlan);
        }

        [HttpPost]
        [Route("api/actionPlan")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var listObjective = _serviceObjective.AddToActionPlan(body.objective);
            var coachingProcess = _serviceCoachingProcess.GetOne(Guid.Parse((string)body.idCoachingProcess));
            var commandActionPlan = new CreateActionPlanCommand(
                listObjective,
                coachingProcess,
                (string)body.description
           );

            var actionPlan = _serviceActionPlan.Create(commandActionPlan);

            return CreateResponse(HttpStatusCode.Created, actionPlan);
        }


        [HttpPut]
        [Route("api/actionPlan")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var listObjective = _serviceObjective.AddToActionPlan(body.objective);
            var coachingProcess = _serviceCoachingProcess.GetOne(Guid.Parse((string)body.idCoachingprocess));
            var commandActionPlan = new UpdateActionPlanCommand(
                Guid.Parse((string)body.id),
                listObjective,
                coachingProcess,
                (string)body.description
           );

            _serviceObjective.CheckObjectiveRemoved(listObjective, Guid.Parse((string)body.id));
            var actionPlan = _serviceActionPlan.Update(commandActionPlan);

            return CreateResponse(HttpStatusCode.Created, actionPlan);
        }

    }
}