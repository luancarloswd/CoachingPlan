using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.EvaluationToolCommands;
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
    [Authorize(Roles = "Administrator, Coach")]
    public class EvaluationToolController : BaseController
    {
        private readonly IEvaluationToolApplicationService _serviceEvaluationTool;
        private readonly IQuestionApplicationService _serviceQuestion;
        private readonly IReplyRepository _serviceReply;
        private readonly IFilledToolCoachApplicationService _serviceFilledToolCoach;
        private readonly IFilledToolCoacheeApplicationService _serviceFilledToolCoachee;
        private readonly ICoachApplicationService _serviceCoach;

        public EvaluationToolController(IEvaluationToolApplicationService serviceEvaluationTool,
            IQuestionApplicationService serviceQuestion,
            IReplyRepository serviceReply,
            IFilledToolCoachApplicationService serviceFilledToolCoach,
            IFilledToolCoacheeApplicationService serviceFilledToolCoachee,
            ICoachApplicationService serviceCoach)
        {
            this._serviceEvaluationTool = serviceEvaluationTool;
            this._serviceQuestion = serviceQuestion;
            this._serviceReply = serviceReply;
            this._serviceFilledToolCoach = serviceFilledToolCoach;
            this._serviceFilledToolCoachee = serviceFilledToolCoachee;
            this._serviceCoach = serviceCoach;
        }

        [HttpGet]
        [Route("api/evaluationTools")]
        public Task<HttpResponseMessage> Get()
        {
            var evaluationTools = _serviceEvaluationTool.GetAllIncludeDetails();
            return CreateResponse(HttpStatusCode.OK, evaluationTools);
        }

        [HttpGet]
        [Route("api/evaluationTools/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var user = _serviceEvaluationTool.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/evaluationTools")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var listQuestion = _serviceQuestion.AddToEvaluationTool(body.question, (ETypeEvaluationTool)body.type);
            var coach = _serviceCoach.GetOneByUser((string)body.idCoach);
            List<Coach> listCoach = _serviceCoach.AddCoach(body.coach);

            listCoach.Add(coach);

            var commandEvaluationTool = new CreateEvaluationToolCommand(
                (string)body.name,
                (ETypeEvaluationTool)body.type,
                listQuestion,
                listCoach,
                (string)body.author
           );

            var evaluationTool = _serviceEvaluationTool.Create(commandEvaluationTool);

            return CreateResponse(HttpStatusCode.Created, evaluationTool);
        }


        [HttpPut]
        [Route("api/evaluationTools")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var listQuestion = _serviceQuestion.AddToEvaluationTool(body.question, (ETypeEvaluationTool)body.type);
            var commandEvaluationTool = new UpdateEvaluationToolCommand(
                Guid.Parse((string)body.id),
                (string)body.name,
                (ETypeEvaluationTool)body.type,
                listQuestion
           );

            _serviceQuestion.CheckQuestionRemoved(listQuestion, Guid.Parse((string)body.id));
            var evaluationTool = _serviceEvaluationTool.Update(commandEvaluationTool);

            return CreateResponse(HttpStatusCode.Created, evaluationTool);
        }

        [HttpDelete]
        [Route("api/evaluationTools/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var evaluationTool = _serviceEvaluationTool.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, evaluationTool);
        }
    }
}