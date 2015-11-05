using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Commands.SessionCommands;

namespace CoachingPlan.ApplicationService
{
    public class SessionApplicationService : BaseApplicationService, ISessionApplicationService
    {
        private ISessionRepository _repositorySession;
        private IPersonApplicationService _servicePerson;
        private ICoacheeRepository _repositoryCoachee;
        private ICoachRepository _repositoryCoach;

        public SessionApplicationService(IPersonApplicationService servicePerson, ISessionRepository repositorySession, ICoacheeRepository repositoryCoachee, ICoachRepository repositoryCoach,  IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repositorySession = repositorySession;
            this._repositoryCoachee = repositoryCoachee;
            this._repositoryCoach = repositoryCoach;
            this._servicePerson = servicePerson;
        }
      

        public void Dispose()
        {
            _repositorySession = null;
        }

        public Session Create(CreateSessionCommand command)
        {
            var session = new Session(command.Theme, command.Date, command.StartTime, command.EndTime, command.Classification, command.CoachingProcess, command.User, command.Job, command.Coach, command.Coachee, command.Observation);
            session.Validate();
            _repositorySession.Create(session);

            if (Commit())
                return session;

            return null;
        }

        public List<Session> Search(dynamic body)
        {
            List<Session> sessions = new List<Session>();
            if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0 && string.IsNullOrEmpty((string)body.idCoachingProcess))
                sessions = GetAll();
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
                sessions = GetAllByCoachingProcess(Guid.Parse((string)body.idCoachingProcess));
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
                sessions = GetAllByClassificationAndCoachingProcess((ESessionClassification)body.classificationSession, Guid.Parse((string)body.idCoachingProcess));
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in GetAllByCoachAndCoachingProcess(person, Guid.Parse((string)body.idCoachingProcess)))
                        sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in GetAllByCoacheeAndCoachingProcess(person, Guid.Parse((string)body.idCoachingProcess)))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in GetAllByClassificationAndCoachAndCoachingProcess((ESessionClassification)body.classificationSession, person, Guid.Parse((string)body.idCoachingProcess)))
                        sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in GetAllByClassificationAndCoacheeAndCoachingProcess((ESessionClassification)body.classificationSession, person, Guid.Parse((string)body.idCoachingProcess)))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var personCoachee in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var personCoach in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                    {
                        foreach (var session in GetAllByCoachAndCoacheeAndCoachingProcess(personCoach, personCoachee, Guid.Parse((string)body.idCoachingProcess)))
                            sessions.Add(session);
                    }
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0 && !string.IsNullOrEmpty((string)body.idCoachingProcess))
            {
                foreach (var personCoachee in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var personCoach in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                    {
                        foreach (var session in GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(personCoach, personCoachee, (ESessionClassification)body.classificationSession, Guid.Parse((string)body.idCoachingProcess)))
                            sessions.Add(session);
                    }
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
                sessions = GetAllByClassification((ESessionClassification)body.classificationSession);
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in GetAllByCoach(person))
                        sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in GetAllByCoachee(person))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                {
                    foreach (var session in GetAllByClassificationAndCoach((ESessionClassification)body.classificationSession, person))
                        sessions.Add(session);
                }
            }
            else if (string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession != 0)
            {
                foreach (var person in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var session in GetAllByClassificationAndCoachee((ESessionClassification)body.classificationSession, person))
                        sessions.Add(session);
                }
            }
            else if (!string.IsNullOrEmpty((string)body.coach.user.person.name) && !string.IsNullOrEmpty((string)body.coachee.user.person.name) && (int)body.classificationSession == 0)
            {
                foreach (var personCoachee in _servicePerson.GetAllByNameIncludeCoachee((string)body.coachee.user.person.name))
                {
                    foreach (var personCoach in _servicePerson.GetAllByNameIncludeCoach((string)body.coach.user.person.name))
                    {
                        foreach (var session in GetAllByCoachAndCoachee(personCoach, personCoachee))
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
                        foreach (var session in GetAllByCoachAndCoacheeAndClassification(personCoach, personCoachee, (ESessionClassification)body.classificationSession))
                            sessions.Add(session);
                    }
                }
            }

            return sessions;
        } 


        public Session Delete(Guid idSession)
        {
            var session = _repositorySession.GetOne(idSession);
            _repositorySession.Delete(session);

            if (Commit())
                return session;

            return null;
        }

        public List<Session> GetAll()
        {
            return _repositorySession.GetAll();
        }

        public List<Session> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _repositorySession.GetAllByCoachingProcess(idCoachingProcess);
        }
        public List<Session> GetAllByCoach(Person coach)
        {
            return _repositorySession.GetAllByCoach(coach);
        }

        public List<Session> GetAllByCoachee(Person coachee)
        {
            return _repositorySession.GetAllByCoachee(coachee);
        }

        public List<Session> GetAllByClassification(ESessionClassification classification)
        {
            return _repositorySession.GetAllByClassification(classification);
        }

        public List<Session> GetAllByClassificationAndCoach(ESessionClassification classification, Person coach)
        {
            return _repositorySession.GetAllByClassificationAndCoach(classification, coach);
        }

        public List<Session> GetAllByClassificationAndCoachee(ESessionClassification classification, Person coachee)
        {
            return _repositorySession.GetAllByClassificationAndCoachee(classification, coachee);
        }

        public List<Session> GetAllByCoachAndCoachee(Person coach, Person coachee)
        {
            return _repositorySession.GetAllByCoachAndCoachee(coach, coachee);
        }

        public List<Session> GetAllByCoachAndCoacheeAndClassification(Person coach, Person coachee, ESessionClassification classification)
        {
            return _repositorySession.GetAllByCoachAndCoacheeAndClassification(coach, coachee, classification);
        }

        public List<Session> GetAll(int take, int skip)
        {
            return _repositorySession.GetAll(take, skip);
        }

        public List<Session> GetAllByCoachAndCoachingProcess(Person coach, Guid idCoachingPrcess)
        {
            return _repositorySession.GetAllByCoachAndCoachingProcess(coach, idCoachingPrcess);
        }

        public List<Session> GetAllByCoacheeAndCoachingProcess(Person coachee, Guid idCoachingProcess)
        {
            return _repositorySession.GetAllByCoacheeAndCoachingProcess(coachee, idCoachingProcess);
        }

        public List<Session> GetAllByClassificationAndCoachingProcess(ESessionClassification classification, Guid idCoachinProcess)
        {
            return _repositorySession.GetAllByClassificationAndCoachingProcess(classification, idCoachinProcess);
        }

        public List<Session> GetAllByClassificationAndCoachAndCoachingProcess(ESessionClassification classification, Person coach, Guid idCoachinProcess)
        {
            return _repositorySession.GetAllByClassificationAndCoachAndCoachingProcess(classification, coach, idCoachinProcess);
        }

        public List<Session> GetAllByClassificationAndCoacheeAndCoachingProcess(ESessionClassification classification, Person coachee, Guid idCoachingProcess)
        {
            return _repositorySession.GetAllByClassificationAndCoacheeAndCoachingProcess(classification, coachee, idCoachingProcess);
        }

        public List<Session> GetAllByCoachAndCoacheeAndCoachingProcess(Person coach, Person coachee, Guid idCoachingProcess)
        {
            return _repositorySession.GetAllByCoachAndCoacheeAndCoachingProcess(coach, coachee, idCoachingProcess);
        }

        public List<Session> GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(Person coach, Person coachee, ESessionClassification classification, Guid idCoachingProcess)
        {
            return _repositorySession.GetAllByCoachAndCoacheeAndClassificationAndCoachingProcess(coach, coachee, classification, idCoachingProcess);
        }

        public Session GetOne(Guid id)
        {
            return _repositorySession.GetOne(id);
        }

        public Session Update(UpdateSessionCommand command)
        {
            var session = _repositorySession.GetOne(command.Id);
            if (command.Classification != 0)
                session.ChangeClassification(command.Classification);
            if (command.Date != DateTime.MinValue)
                session.ChangeDate(command.Date);
            if (command.EndTime != TimeSpan.MinValue)
                session.ChangeEndTime(command.EndTime);
            if (command.StartTime != TimeSpan.MinValue)
                session.ChangeStartTime(command.StartTime);
            if (command.Theme!= null)
                session.ChangeTheme(command.Theme);
            if (command.CoachingProcess != null)
                session.ChangeCoachingProcess(command.CoachingProcess);
            if (!string.IsNullOrEmpty(command.Observation))
                session.ChangeObservation(command.Observation);

            if (command.Coach != null)
            {
                foreach (var coach in command.Coach)
                {
                    session.AddEvaluationCoach(coach);
                }
            }

            if (command.Coachee != null)
            {
                foreach (var coachee in command.Coachee)
                {
                    session.AddEvaluationCoachee(coachee);
                }
            }

            if (command.Job != null)
            {
                foreach (var job in command.Job)
                {
                    session.AddJob(job);
                }
            }


            _repositorySession.Update(session);

            if (Commit())
                return session;

            return null;
        }

    }
}
