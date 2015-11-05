using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.ObjectiveCommands;

namespace CoachingPlan.ApplicationService
{
    public class ObjectiveApplicationService : BaseApplicationService, IObjectiveApplicationService
    {
        private IObjectiveRepository _repository;
        private IMarkApplicationService _serviceMark;

        public ObjectiveApplicationService(IObjectiveRepository repository, IMarkApplicationService serviceMark, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._serviceMark = serviceMark;
        }
        public Objective Create(CreateObjectiveCommand command)
        {
            var service = new Objective(command.Description, command.Term, command.Mark);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public List<Objective> AddToActionPlan(dynamic body)
        {
            List<Objective> listObjective = new List<Objective>();
            foreach (var item in body)
            {
                var listMark = _serviceMark.AddToObjective(item.mark);
                if ((item.term != null) || (item.term != ""))
                {
                    if (item.id != null)
                        listObjective.Add(
                            Update(new UpdateObjectiveCommand(
                            Guid.Parse((string)item.id),
                            listMark,
                            (DateTime)item.term,
                            (string)item.description)));
                    else
                        listObjective.Add(new Objective(
                            (string)item.description,
                            (DateTime)item.term,
                            listMark));
                }
                if (item.id != null)
                    _serviceMark.CheckMarkRemoved(listMark, Guid.Parse((string)item.id));
            }
            return listObjective;
        }
        public void CheckObjectiveRemoved(List<Objective> listObjective, Guid idActionPlan)
        {
            var oldList = _repository.GetAllByActionPlan(idActionPlan);
            foreach (var objective in oldList)
            {
                if (!listObjective.Contains(objective))
                {
                    _repository.Delete(objective);
                }
            }
        }
        public Objective Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Objective> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Objective> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Objective GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Objective> GetAllByActionPlan(Guid idActionPlan)
        {
            return _repository.GetAllByActionPlan(idActionPlan);
        }
        public Objective Update(UpdateObjectiveCommand command)
        {
            var Objective = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Description))
                Objective.ChangeDescription(command.Description);
            if (command.Term != null)
                Objective.ChangeTerm(command.Term);

            if (command.Mark != null)
            {
                foreach (var mark in command.Mark)
                {
                    Objective.AddMark(mark);
                }
            }

            _repository.Update(Objective);

            if (Commit())
                return Objective;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
