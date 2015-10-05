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
using System.Data.Entity;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SessionController : BaseController
    {
        private readonly ISessionApplicationService _serviceSession;
        private readonly ICoachApplicationService _serviceCoach;
        private readonly ICoacheeApplicationService _serviceCoachee;
        private readonly IPersonApplicationService _servicePerson;


        public SessionController(ISessionApplicationService serviceSession, ICoachApplicationService serviceCoach, ICoacheeApplicationService serviceCoachee, IPersonApplicationService servicePerson)
        {
            this._serviceSession = serviceSession;
            this._serviceCoach = serviceCoach;
            this._serviceCoachee = serviceCoachee;
            this._servicePerson = servicePerson;
        }

        [HttpGet]
        [Route("api/sessions")]
        public Task<HttpResponseMessage> Get()
        {
            var sessions = _serviceSession.GetAll();

            return CreateResponse(HttpStatusCode.OK, sessions);
        }

        [HttpGet]
        [Route("api/sessions/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var session = _serviceSession.GetOne(Guid.Parse(id));

            return CreateResponse(HttpStatusCode.OK, session);
        }
        [HttpPost]
        [Route("api/sessions/search")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            List<Session> sessions = new List<Session>();
            if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
                sessions = _serviceSession.GetAll();
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
                sessions = _serviceSession.GetAllByClassification((ESessionClassification)body.classificationSession);
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in _serviceSession.GetAllByCoach(person))
                        sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in _serviceSession.GetAllByCoachee(person))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in _serviceSession.GetAllByClassificationAndCoach((ESessionClassification)body.classificationSession, person))
                    sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in _serviceSession.GetAllByClassificationAndCoachee((ESessionClassification)body.classificationSession, person))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var personCoachee in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var personCoach in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                    {
                        foreach (var session in _serviceSession.GetAllByCoachAndCoachee(personCoach, personCoachee))
                            sessions.Add(session);
                    }
                }
            }
            else
            {
                foreach (var personCoachee in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var personCoach in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                    {
                        foreach (var session in _serviceSession.GetAllByCoachAndCoacheeAndClassification(personCoach, personCoachee, (ESessionClassification)body.classificationSession))
                            sessions.Add(session);
                    }
                }
            }
            return CreateResponse(HttpStatusCode.Created, sessions);
        }
    }
}