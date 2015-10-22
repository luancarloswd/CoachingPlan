using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.CoachCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class CoachApplicationService : BaseApplicationService, ICoachApplicationService
    {
        private ICoachRepository _repository;

        public CoachApplicationService(ICoachRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Coach Create(CreateCoachCommand command)
        {
            var coach = new Coach(command.IdUser, command.EvaluationTool, command.Speciality, command.Formation, command.CoachingProcess);
            _repository.Create(coach);

            if (Commit())
                return coach;

            return null;
        }

        public Coach Delete(Guid id)
        {
            var Coach = _repository.GetOne(id);
            _repository.Delete(Coach);

            if (Commit())
                return Coach;

            return null;
        }

        public List<Coach> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Coach> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Coach GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public Coach GetOneIncludeDetails(Guid id)
        {
            return _repository.GetOneIncludeDetails(id);
        }
        public Coach GetOneByUser(string idUser)
        {
            return _repository.GetOneByUser(idUser);
        }
        public Coach Update(UpdateCoachCommand commandCoach)
        {
            Coach coach = _repository.GetOneIncludeDetails(commandCoach.Id);
            foreach (var speciality in commandCoach.Speciality)
            {
                coach.AddSpeciality(speciality);
            }
            foreach (var formation in commandCoach.Formation)
            {
                coach.AddFormation(formation);
            }
            _repository.Update(coach);

            if (Commit())
                return coach;

            return null;
        }

        public List<Coach> AddCoach(dynamic body)
        {
            List<Coach> listCoach = new List<Coach>();
            foreach (var item in body)
            {
                    listCoach.Add(GetOneIncludeCoachingProcess(Guid.Parse((string)item.id)));
            }
            return listCoach;
        }
        public CoachingProcess CheckCoachRemovedOfCoachingProcess(List<Coach> listCoachingProcess, CoachingProcess coachingProcess)
        {
            var oldList = _repository.GetAllByCoachingProcess(coachingProcess.Id);
            foreach (var coach in oldList)
            {
                if (!listCoachingProcess.Contains(coach))
                {
                    coachingProcess.RemoveCoach(coach);
                }
            }
            foreach (var coach in listCoachingProcess)
                coachingProcess.AddCoach(coach);

            return coachingProcess;
        }
        public Coach GetOneIncludeCoachingProcess(Guid id)
        {
            return _repository.GetOneIncludeCoachingProcess(id);
        }
        public List<Coach> GetAllIncludeDetails()
        {
            return _repository.GetAllIncludeDetails();
        }

        public List<Coach> GetAllIncludePerson()
        {
            return _repository.GetAllIncludePerson();
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
