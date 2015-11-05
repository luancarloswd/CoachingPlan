using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.SpecialityCommands;
using CoachingPlan.Domain.Commands.StrongPointCommands;
using CoachingPlan.Domain.Enums;

namespace CoachingPlan.ApplicationService
{
    public class StrongPointApplicationService : BaseApplicationService, IStrongPointApplicationService
    {
        private IStrongPointRepository _repository;

        public StrongPointApplicationService(IStrongPointRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public StrongPoint Create(CreateStrongPointCommand command)
        {
            var StrongPoint = new StrongPoint(command.Name, command.Class, command.Description);
            StrongPoint.Validate();
            _repository.Create(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public StrongPoint Delete(Guid id)
        {
            var StrongPoint = _repository.GetOne(id);
            _repository.Delete(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public List<StrongPoint> GetAll()
        {
            return _repository.GetAll();
        }

        public List<StrongPoint> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public StrongPoint GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public StrongPoint GetOnebyCoachee(Guid idCoachee)
        {
            return _repository.GetOneByCoachee(idCoachee);
        }
        public StrongPoint Update(ChangeStrongPointCommand command)
        {
            var StrongPoint = _repository.GetOne(command.Id);
            if(!string.IsNullOrEmpty(command.Name))
                StrongPoint.ChangeName(command.Name);
            if (!string.IsNullOrEmpty(command.Description))
                StrongPoint.ChangeDescription(command.Description);

                StrongPoint.ChangeClass(command.Class);

            _repository.Update(StrongPoint);

            if (Commit())
                return StrongPoint;

            return null;
        }

        public List<StrongPoint> AddToCoachee(dynamic body)
        {
            List<StrongPoint> listStrongPoint = new List<StrongPoint>();
            foreach (var item in body)
            {
                if ((item.name != null) || (item.name != ""))
                {
                    if (item.id != null)
                        listStrongPoint.Add(Update(new ChangeStrongPointCommand(
                            Guid.Parse((string)item.id),
                            (string)item.name,
                            (EClassStrongPoint)item.classStrongPoint,
                            (string)item.description
                            )));
                    else
                        listStrongPoint.Add(new StrongPoint(
                            (string)item.name,
                            (EClassStrongPoint)item.typeClass,
                            (string)item.description
                        ));
                }
            }

            return listStrongPoint;
        }
        public void CheckStrongPointRemoved(List<StrongPoint> listWeakness, Guid idCoachee)
        {
            var oldList = _repository.GetAllByCoachee(idCoachee);
            foreach (var strongPoint in oldList)
            {
                if (!listWeakness.Contains(strongPoint))
                {
                    _repository.Delete(strongPoint);
                }
            }
        }
        public void Dispose()
        {
            _repository = null;
        }

    }
}
