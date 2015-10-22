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
        private readonly IActionPlanApplicationService _serviceActionPlan;

        public CoachingProcessController(ICoachingProcessApplicationService coachingProcess,
            ICoachApplicationService serviceCoach,
            ICoacheeApplicationService serviceCoachee,
            IPerformanceIndicatorApplicationService servicePerformanceIndicator,
            IServiceApplicationService service,
            IActionPlanApplicationService serviceActionplan)
        {
            this._serviceActionPlan = serviceActionplan;
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
            var listCoach = _serviceCoach.AddCoach(body.coachs);

            var listCoachee = _serviceCoachee.AddCoachee(body.coachees);

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
            var listCoach = _serviceCoach.AddCoach(body.coach);
            var listCoachee = _serviceCoachee.AddCoachee(body.coachee);
            var listPerformanceIndicator = _servicePerformanceIndicator.AddToCoachingProcess(body.performanceIndicator);
            var listService = _service.AddToCoachingProcess(body.service);


            if (body.endDate == null || body.endDate == "")
                body.endDate = DateTime.MinValue;

            var coachingProcess = _serviceCoachingProcess.GetOneIncludeDetails(Guid.Parse((string)body.id));

            coachingProcess = _serviceCoach.CheckCoachRemovedOfCoachingProcess(listCoach, coachingProcess);
            coachingProcess = _serviceCoachee.CheckCoacheeRemovedOfCoachingProcess(listCoachee, coachingProcess);
            coachingProcess = _service.CheckServiceRemoved(listService, coachingProcess);

            var commandCoachingProcess = new UpdateCoachingProcessCommand(
                id: Guid.Parse((string)body.id),
                name: (string)body.name,
                startDate: (DateTime)body.startDate,
                endDate: (DateTime)body.endDate,
                mode: (EModeProcess)body.mode,
                coach: coachingProcess.Coach,
                coachee: coachingProcess.Coachee,
                performanceIndicator: listPerformanceIndicator,
                service: coachingProcess.Service,
                observation: (string)body.observation
              );

            _servicePerformanceIndicator.CheckPerformanceIndicatorRemoved(listPerformanceIndicator, coachingProcess.Id);
            coachingProcess = _serviceCoachingProcess.Update(commandCoachingProcess);

            return CreateResponse(HttpStatusCode.Created, coachingProcess);
        }

        [HttpDelete]
        [Route("api/coachingProcesss/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var coachingProcess = _serviceCoachingProcess.Delete(Guid.Parse(id));
            if (coachingProcess.ActionPlan != null)
                _serviceActionPlan.Delete(coachingProcess.ActionPlan.Id);
            return CreateResponse(HttpStatusCode.OK, coachingProcess);
        }
    }
}