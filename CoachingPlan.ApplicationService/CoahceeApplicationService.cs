using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.CoacheeCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class CoacheeApplicationService : BaseApplicationService, ICoacheeApplicationService
    {
        private ICoacheeRepository _repository;

        public CoacheeApplicationService(ICoacheeRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Coachee Create(CreateCoacheeCommand command)
        {
            var Coachee = new Coachee(command.Profession, command.IdUser, command.Weakness, command.StrongPoint, command.CoachingProcess);
            Coachee.Validate();
            _repository.Create(Coachee);

            if (Commit())
                return Coachee;

            return null;
        }

        public Coachee Delete(Guid id)
        {
            var Coachee = _repository.GetOne(id);
            _repository.Delete(Coachee);

            if (Commit())
                return Coachee;

            return null;
        }

        public List<Coachee> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Coachee> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Coachee GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public Coachee GetOneByUser(string idUser)
        {
            return _repository.GetOneByUser(idUser);
        }
        public Coachee GetOneIncludeDetails(Guid id)
        {
            return _repository.GetOneIncludeDetails(id);
        }
        public Coachee Update(UpdateCoacheeCommand command)
        {
            var coachee = _repository.GetOne(command.Id);
            if(command.Profession != null)
                coachee.ChangeProfession(command.Profession);

            foreach (var weakness in command.Weakness)
            {
                coachee.AddWeakness(weakness);
            }
            foreach (var strongPoint in command.StrongPoint)
            {
                coachee.AddStrongPoint(strongPoint);
            }

            _repository.Update(coachee);

            if (Commit())
                return coachee;

            return null;
        }

        public List<Coachee> GetAllIncludeDetails()
        {
            return _repository.GetAllIncludeDetails();
        }
        public List<Coachee> GetAllIncludePerson()
        {
            return _repository.GetAllIncludePerson();
        }
        public void Dispose()
        {
            _repository = null;
        }

    }
}
