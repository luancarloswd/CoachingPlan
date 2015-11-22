using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.Api.Controllers
{

    public class ReportsController : BaseController
    {

        private readonly ICoacheeApplicationService _serviceCoachee;
        private readonly ISessionApplicationService _serviceSession;
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;

        public ReportsController(
            ICoacheeApplicationService serviceCoachee,
            ISessionApplicationService serviceSession,
            ICoachingProcessApplicationService serviceCoachingProcess)
        {
            this._serviceCoachee = serviceCoachee;
            this._serviceCoachingProcess = serviceCoachingProcess;
            this._serviceSession = serviceSession;
        }
        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/reports/coachees")]
        public Task<HttpResponseMessage> Coachees()
        {
            var coachees = _serviceCoachee.GetAllIncludeProcess();

            return CreateResponse(HttpStatusCode.OK, coachees);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/reports/sessions")]
        public Task<HttpResponseMessage> Sessions()
        {
            var sessions = _serviceSession.GetAllIncludeDetails();

            return CreateResponse(HttpStatusCode.OK, sessions);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/reports/utilization/{id}")]
        public Task<HttpResponseMessage> Utilization(string id)
        {
            var coachingProcess = _serviceCoachingProcess.UtilizationCoachingProcess(Guid.Parse(id));

            return CreateResponse(HttpStatusCode.OK, coachingProcess);
        }
    }
}