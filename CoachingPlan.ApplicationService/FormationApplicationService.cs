using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.FormationCommands;

namespace CoachingPlan.ApplicationService
{
    public class FormationApplicationService : BaseApplicationService, IFormationApplicationService
    {
        private IFormationRepository _repository;

        public FormationApplicationService(IFormationRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Formation Create(CreateFormationCommand command)
        {
            var Formation = new Formation(command.Name, command.Description);
            Formation.Validate();
            _repository.Create(Formation);

            if (Commit())
                return Formation;

            return null;
        }

        public Formation Delete(Guid id)
        {
            var formation = _repository.GetOne(id);
            _repository.Delete(formation);

            if (Commit())
                return formation;

            return null;
        }

        public List<Formation> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Formation> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Formation GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public Formation GetOnebyCoach(Guid idCoach)
        {
            return _repository.GetOneByCoach(idCoach);
        }
        public Formation Update(ChangeFormationCommand command)
        {
            var formation = _repository.GetOne(command.Id);
            if(!string.IsNullOrEmpty(command.Name))
                formation.ChangeName(command.Name);
            if (!string.IsNullOrEmpty(command.Description))
                formation.ChangeDescription(command.Description);

            _repository.Update(formation);

            if (Commit())
                return formation;

            return null;
        }
        public List<Formation> AddToCoach(dynamic body)
        {
            List<Formation> listFormation = new List<Formation>();
            foreach (var item in body)
            {
                if ((item.name != null) || (item.name != ""))
                {
                    if (item.id != null)
                        listFormation.Add(Update(new ChangeFormationCommand(
                            Guid.Parse((string)item.id),
                            (string)item.name,
                            (string)item.description
                            )));
                    else
                        listFormation.Add(new Formation(
                            (string)item.name,
                            (string)item.description
                        ));
                }
            }

            return listFormation;
        }
        public void CheckFormationRemoved(List<Formation> listFormation, Guid idCoach)
        {
            var oldList = _repository.GetAllByCoach(idCoach);
            foreach (var formation in oldList)
            {
                if (!listFormation.Contains(formation))
                {
                    _repository.Delete(formation);
                }
            }
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
