using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.EvaluationToolCommands;
using CoachingPlan.Domain.Commands.FilledToolCoachCommands;
using CoachingPlan.Domain.Commands.FilledToolCoacheeCommands;
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
        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/evaluationTools")]
        public Task<HttpResponseMessage> Get()
        {
            var evaluationTools = _serviceEvaluationTool.GetAllIncludeDetails();
            return CreateResponse(HttpStatusCode.OK, evaluationTools);
        }

        [Authorize(Roles = "Administrator, Coach, Coachee")]
        [HttpGet]
        [Route("api/filledTool/{id}/{role}")]
        public Task<HttpResponseMessage> GetFilledTool(string id, string role)
        {
            if (role == "Coach")
            {
                var filledToll = _serviceFilledToolCoach.GetOne(Guid.Parse(id));
                return CreateResponse(HttpStatusCode.OK, filledToll);
            }
            if (role == "Coachee")
            {
                var filledToll = _serviceFilledToolCoachee.GetOne(Guid.Parse(id));
                return CreateResponse(HttpStatusCode.OK, filledToll);
            }
            else
                return CreateResponse(HttpStatusCode.BadRequest, null);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/evaluationTools/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var user = _serviceEvaluationTool.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpPost]
        [Route("api/filledToll")]
        public Task<HttpResponseMessage> FilledToll([FromBody]dynamic body)
        {
            var role = (string)body.role;
            var evaluationToolOrigin = _serviceEvaluationTool.GetOne(Guid.Parse((string)body.idEvaluationTool));
            List<Question> listQuestion = new List<Question>();
            foreach (var question in evaluationToolOrigin.Question)
            {
                List<Reply> listReply = new List<Reply>();
                foreach (var reply in question.Reply)
                    listReply.Add(new Reply(reply.BodyReply, reply.Group));
                listQuestion.Add(new Question(question.TypeReply, question.TypeQuestion, question.StepQuestion, question.Enunciation, question.Education, listReply, question.PhaseQuestion, question.Group));

            }

            var newEvaluationToolFilled = _serviceEvaluationTool.Create(new CreateEvaluationToolCommand(
                evaluationToolOrigin.Name,
                evaluationToolOrigin.Type,
                listQuestion,
                evaluationToolOrigin.Coach,
                evaluationToolOrigin.Author
           ));

            if (role == "Coachee")
            {
                var commandFilledTool = new CreateFilledToolCoacheeCommand(
                   DateTime.MinValue,
                   newEvaluationToolFilled.Id,
                   Guid.Parse((string)body.idCoachingProcess),
                   Guid.Parse((string)body.idUser)
               );
                var filledTool = _serviceFilledToolCoachee.Create(commandFilledTool);
                return CreateResponse(HttpStatusCode.Created, filledTool);
            }
            else if (role == "Coach")
            {
                var commandFilledTool = new CreateFilledToolCoachCommand(
                   DateTime.MinValue,
                   Guid.Parse((string)body.idEvaluationTool),
                   Guid.Parse((string)body.idCoachingProcess),
                   Guid.Parse((string)body.idUser)
               );
                var filledTool = _serviceFilledToolCoach.Create(commandFilledTool);
                return CreateResponse(HttpStatusCode.Created, filledTool);
            } 

            return CreateResponse(HttpStatusCode.BadRequest, null);
        }

        [Authorize(Roles = "Administrator, Coach, Coachee")]
        [HttpPut]
        [Route("api/evaluationTools/fill")]
        public Task<HttpResponseMessage> Fill([FromBody]dynamic body)
        {
            if (body.role == "Coachee")
            {
                var commandFilledTool = new UpdateFilledToolCoacheeCommand(
                   Guid.Parse((string)body.id),
                   DateTime.Now,
                   Guid.Parse((string)body.idEvaluationTool),
                   Guid.Parse((string)body.idCoachee)
               );
                var filledTool = _serviceFilledToolCoachee.Update(commandFilledTool);
            }
            else if (body.role == "Coach")
            {
                var commandFilledTool = new UpdateFilledToolCoachCommand(
                   Guid.Parse((string)body.id),
                   DateTime.Now,
                   Guid.Parse((string)body.idEvaluationTool),
                   Guid.Parse((string)body.idCoach)
               );
                var filledTool = _serviceFilledToolCoach.Update(commandFilledTool);
            }
            else
                return CreateResponse(HttpStatusCode.BadRequest, null);

            var listQuestion = _serviceQuestion.AddToEvaluationTool(body.evaluationTool.question, (ETypeEvaluationTool)body.evaluationTool.type);
            var commandEvaluationTool = new UpdateEvaluationToolCommand(
                Guid.Parse((string)body.evaluationTool.id),
                (string)body.evaluationTool.name,
                (ETypeEvaluationTool)body.evaluationTool.type,
                listQuestion
           );
            
            var evaluationTool = _serviceEvaluationTool.Update(commandEvaluationTool);

            return CreateResponse(HttpStatusCode.OK, evaluationTool);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpPost]
        [Route("api/evaluationTools")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var listQuestion = _serviceQuestion.AddToEvaluationTool(body.question, (ETypeEvaluationTool)body.type);
            var coach = _serviceCoach.GetOneByUser((string)body.idCoach);
            List<Coach> listCoach = _serviceCoach.AddCoach(body.coach);
            if (coach != null)
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


        [Authorize(Roles = "Administrator, Coach")]
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

        [Authorize(Roles = "Administrator, Coach")]
        [HttpDelete]
        [Route("api/evaluationTools/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var evaluationTool = _serviceEvaluationTool.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, evaluationTool);
        }
    }
}