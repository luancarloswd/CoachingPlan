using CoachingPlan.API.Controllers;
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
using CoachingPlan.Domain.Commands.SessionCommands;
using System.Security.Claims;
using System.Linq;
using CoachingPlan.Domain.Commands.EvaluationCoachCommands;
using CoachingPlan.Domain.Commands.EvaluationCoacheeCommands;
using Microsoft.AspNet.Identity;

namespace CoachingPlan.Api.Controllers
{
    public class SessionController : BaseController
    {
        private readonly ISessionApplicationService _serviceSession;
        private readonly IEvaluationCoachApplicationService _serviceEvaluationCoach;
        private readonly IEvaluationCoacheeApplicationService _serviceEvaluationCoachee;
        private readonly IPersonApplicationService _servicePerson;
        private readonly IJobApplicationService _serviceJob;
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;
        private readonly IUserApplicationService _serviceUser;


        public SessionController(ISessionApplicationService serviceSession, 
            IEvaluationCoachApplicationService serviceEvaluationCoach, 
            IEvaluationCoacheeApplicationService serviceEvaluationCoachee, 
            IPersonApplicationService servicePerson,
            IJobApplicationService serviceJob,
            ICoachingProcessApplicationService serviceCoachingProcess,
            IUserApplicationService serviceUser)
        {
            this._serviceSession = serviceSession;
            this._serviceEvaluationCoach = serviceEvaluationCoach;
            this._serviceEvaluationCoachee = serviceEvaluationCoachee;
            this._servicePerson = servicePerson;
            this._serviceJob = serviceJob;
            this._serviceCoachingProcess = serviceCoachingProcess;
            this._serviceUser = serviceUser;
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager, Coachee")]
        [HttpGet]
        [Route("api/sessions")]
        public Task<HttpResponseMessage> Get()
        {
            var sessions = _serviceSession.GetAll();

            return CreateResponse(HttpStatusCode.OK, sessions);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager, Coachee")]
        [HttpGet]
        [Route("api/sessions/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var session = _serviceSession.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, session);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager, Coachee")]
        [HttpGet]
        [Route("api/sessions/byCoachingProcess/{id}")]
        public Task<HttpResponseMessage> GetByCoachingProcess(string id)
        {
            var sessions = _serviceSession.GetAllByCoachingProcess(Guid.Parse(id));

            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var role = principal.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Single().Value;
            if (role == "Coachee")
            {
                foreach (var session in sessions)
                {
                     foreach (var evaluation in session.EvaluationCoachee)
                        if (evaluation.Coachee.IdUser == User.Identity.GetUserId())
                            return CreateResponse(HttpStatusCode.OK, sessions);
                }
                return CreateResponse(HttpStatusCode.Unauthorized, null);
            }

            return CreateResponse(HttpStatusCode.OK, sessions);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager, Coachee")]
        [HttpPost]
        [Route("api/sessions/search")]
        public Task<HttpResponseMessage> Search([FromBody]dynamic body)
        {
            List<Session> sessions = _serviceSession.Search(body);

            return CreateResponse(HttpStatusCode.Created, sessions);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager")]
        [HttpPost]
        [Route("api/sessions")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var validate= _serviceSession.GetAllByCoachingProcess(Guid.Parse((string)body.coachingProcess.id));
            foreach(var item in  validate)
                if (item.StartTime == (TimeSpan)body.startTime && item.Date == (DateTime)body.date)
                    return CreateResponse(HttpStatusCode.BadRequest, null);

            var listJob = _serviceJob.AddJobToSession(body.job);
            var coachingProcess = _serviceCoachingProcess.GetOne(Guid.Parse((string)body.coachingProcess.id));
            var user = _serviceUser.GetOne((string)body.idUser);
            var commandSession = new CreateSessionCommand(
                coachingProcess,
                (string)body.theme,
                user,
                (DateTime)body.date,
                (TimeSpan)body.startTime,
                (TimeSpan)body.endTime,
                (ESessionClassification)body.classification,
                (string)body.observation,
                listJob
           );

            var session = _serviceSession.Create(commandSession);

            _serviceEvaluationCoach.AddToSession(body.coach, session.Id);
            _serviceEvaluationCoachee.AddToSession(body.coachee, session.Id);

            return CreateResponse(HttpStatusCode.Created, session);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager, Coachee")]
        [HttpPut]
        [Route("api/sessions/evaluation")]
        public Task<HttpResponseMessage> Evaluation([FromBody]dynamic body)
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            var role = principal.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Single().Value;
            if (role  == "Coach")
            {
                _serviceEvaluationCoach.Update(new UpdateEvaluationCoachCommand(Guid.Parse((string)body.id), (int)body.evaluation, (string)body.observation));
            }
            if (role == "Coachee")
            {
                _serviceEvaluationCoachee.Update(new UpdateEvaluationCoacheeCommand(Guid.Parse((string)body.id), (int)body.evaluation, (string)body.observation));
            }
            return CreateResponse(HttpStatusCode.Created, true);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager")]
        [HttpPut]
        [Route("api/sessions")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            List<Job> listJob = _serviceJob.AddJobToSession(body.job);
            var user = _serviceUser.GetOne((string)body.idUser);
            var coachingProcess = _serviceCoachingProcess.GetOne(Guid.Parse((string)body.idCoachingProcess));

            var session = _serviceSession.GetOne(Guid.Parse((string)body.id));
            
            session = _serviceJob.CheckJobRemovedOfSession(listJob, session);

            var commandSession = new UpdateSessionCommand(
                Guid.Parse((string)body.id),
                coachingProcess,
                (string)body.theme,
                user,
                (DateTime)body.date,
                (TimeSpan)body.startTime,
                (TimeSpan)body.endTime,
                (ESessionClassification)body.classification,
                (string)body.observation,
                session.Job,
                session.EvaluationCoach,
                session.EvaluationCoachee
           );

            session = _serviceSession.Update(commandSession);
            var listEvaluationCoach = _serviceEvaluationCoach.AddToSession(body.coach, session.Id);
            _serviceEvaluationCoach.CheckEvaluationCoachRemoved(listEvaluationCoach, session.Id);

            var listEvaluationCoachee = _serviceEvaluationCoachee.AddToSession(body.coachee, session.Id);
            _serviceEvaluationCoachee.CheckEvaluationCoacheeRemoved(listEvaluationCoachee, session.Id);

            return CreateResponse(HttpStatusCode.Created, session);
        }

        [Authorize(Roles = "Administrator, Coach, SessionManager")]
        [HttpDelete]
        [Route("api/sessions/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var session = _serviceSession.Delete(Guid.Parse(id));
            foreach (var evaluation in session.EvaluationCoach)
                _serviceEvaluationCoach.Delete(evaluation.Id);
            foreach (var evaluation in session.EvaluationCoachee)
                _serviceEvaluationCoachee.Delete(evaluation.Id);
            return CreateResponse(HttpStatusCode.OK, session);
        }
    }
}