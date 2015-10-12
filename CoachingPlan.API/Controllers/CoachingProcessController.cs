using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.CoachingProcessCommands;
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
    [Authorize(Roles = "Administrator")]
    public class CoachingProcessController : BaseController
    {
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;
        private readonly ICoachApplicationService _serviceCoach;
        private readonly ICoacheeApplicationService _serviceCoachee;
        private readonly IPerformanceIndicatorApplicationService _servicePerformanceIndicator;
        private readonly IServiceApplicationService _service;

        public CoachingProcessController(ICoachingProcessApplicationService coachingProcess,
            ICoachApplicationService serviceCoach,
            ICoacheeApplicationService serviceCoachee,
            IPerformanceIndicatorApplicationService servicePerformanceIndicator,
            IServiceApplicationService service)
        {
            this._serviceCoachingProcess = coachingProcess;
            this._serviceCoach = serviceCoach;
            this._serviceCoachee = serviceCoachee;
            this._servicePerformanceIndicator = servicePerformanceIndicator;
            this._service = service;
        }

        [HttpGet]
        [Route("api/coachingProcesss")]
        public Task<HttpResponseMessage> Get()
        {
            var coachingProcesss = _serviceCoachingProcess.GetAll();
            return CreateResponse(HttpStatusCode.OK, coachingProcesss);
        }

        [HttpGet]
        [Route("api/coachingProcesss/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var coachingProcess = _serviceCoachingProcess.GetOneIncludeDetails(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, coachingProcess);
        }

        [HttpPost]
        [Route("api/coachingProcesss")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var listCoach = _serviceCoach.AddToCoachingProcess(body.coachs);

            var listCoachee = _serviceCoachee.AddToCoachingProcess(body.coachees);

            var listPerformanceIndicator = _servicePerformanceIndicator.AddToCoachingProcess(body.performanceIndicator);

            var listService = _service.AddToCoachingProcess(body.services);

            if (body.endDate == null || body.endDate == "")
                body.endDate = DateTime.MinValue;

            var commandCoachingProcess = new CreateCoachingProcessCommand(
                name: (string)body.name,
                startDate: (DateTime)body.startDate,
                endDate: (DateTime)body.endDate,
                mode: (EModeProcess)body.mode,
                coach: listCoach,
                coachee: listCoachee,
                performanceIndicator: listPerformanceIndicator,
                service: listService,
                observation: (string)body.observation
           );

            var coachingProcess = _serviceCoachingProcess.Create(commandCoachingProcess);

            return CreateResponse(HttpStatusCode.Created, coachingProcess);
        }


        [HttpPut]
        [Route("api/coachingProcesss")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var listCoach = _serviceCoach.AddToCoachingProcess(body.coach);
            var listCoachee = _serviceCoachee.AddToCoachingProcess(body.coachee);
            var listPerformanceIndicator = _servicePerformanceIndicator.AddToCoachingProcess(body.performanceIndicator);
            var listService = _service.AddToCoachingProcess(body.service);


            if (body.endDate == null || body.endDate == "")
                body.endDate = DateTime.MinValue;

            var commandCoachingProcess = new UpdateCoachingProcessCommand(
                id: Guid.Parse((string)body.id),
                name: (string)body.name,
                startDate: (DateTime)body.startDate,
                endDate: (DateTime)body.endDate,
                mode: (EModeProcess)body.mode,
                coach: listCoach,
                coachee: listCoachee,
                performanceIndicator: listPerformanceIndicator,
                service: listService,
                observation: (string)body.observation
              );

            var coachingProcess = _serviceCoachingProcess.Update(commandCoachingProcess);

            _serviceCoach.CheckCoachRemoved(listCoach, coachingProcess.Id);
            _serviceCoachee.CheckCoacheeRemoved(listCoachee, coachingProcess.Id);
            _servicePerformanceIndicator.CheckPerformanceIndicatorRemoved(listPerformanceIndicator, coachingProcess.Id);
            _service.CheckServiceRemoved(listService, coachingProcess.Id);

            return CreateResponse(HttpStatusCode.Created, coachingProcess);
        }

        [HttpDelete]
        [Route("api/coachingProcesss/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var coachingProcess = _serviceCoachingProcess.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, coachingProcess);
        }
    }
}