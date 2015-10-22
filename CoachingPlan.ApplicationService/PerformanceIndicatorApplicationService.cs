using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.PerformanceIndicatorCommands;

namespace CoachingPlan.ApplicationService
{
    public class PerformanceIndicatorApplicationService : BaseApplicationService, IPerformanceIndicatorApplicationService
    {
        private IPerformanceIndicatorRepository _repository;

        public PerformanceIndicatorApplicationService(IPerformanceIndicatorRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public PerformanceIndicator Create(CreatePerformanceIndicatorCommand command)
        {
            var performanceIndicator = new PerformanceIndicator(command.Indicator);
            performanceIndicator.Validate();
            _repository.Create(performanceIndicator);

            if (Commit())
                return performanceIndicator;

            return null;
        }

        public PerformanceIndicator Delete(Guid id)
        {
            var performanceIndicator = _repository.GetOne(id);
            _repository.Delete(performanceIndicator);

            if (Commit())
                return performanceIndicator;

            return null;
        }

        public List<PerformanceIndicator> GetAll()
        {
            return _repository.GetAll();
        }

        public List<PerformanceIndicator> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public PerformanceIndicator GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<PerformanceIndicator> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _repository.GetAllByCoachingProcess(idCoachingProcess);
        }
        public PerformanceIndicator Update(UpdatePerformanceIndicatorCommand command)
        {
            var performanceIndicator = _repository.GetOne(command.Id);
            if (command.Indicator != null)
                performanceIndicator.ChangeIndicator(command.Indicator);

            _repository.Update(performanceIndicator);

            if (Commit())
                return performanceIndicator;

            return null;
        }

        public List<PerformanceIndicator> AddToCoachingProcess(dynamic body)
        {
            List<PerformanceIndicator> listPerformanceIndicator = new List<PerformanceIndicator>();
            foreach (var item in body)
            {
                if ((item.indicator != null) || (item.indicator != ""))
                {
                    if (item.id != null)
                    {
                        listPerformanceIndicator.Add(
                            Update(new UpdatePerformanceIndicatorCommand(Guid.Parse((string)item.id), (string)item.indicator)));
                    }
                    else
                    {
                        listPerformanceIndicator.Add(new PerformanceIndicator(
                            (string)item.indicator)
                        );
                    }
                }
            }
            return listPerformanceIndicator;
        }

        public void CheckPerformanceIndicatorRemoved(List<PerformanceIndicator> listPerformanceIndicator, Guid idCoachingProcess)
        {
            var oldList = _repository.GetAllByCoachingProcess(idCoachingProcess);
            foreach (var performanceIndicator in oldList)
            {
                if (!listPerformanceIndicator.Contains(performanceIndicator))
                {
                    _repository.Delete(performanceIndicator);
                }
            }
        }
        public void Dispose()
        {
            _repository = null;
        }

    }
}
