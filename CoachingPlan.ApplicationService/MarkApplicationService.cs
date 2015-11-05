using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.MarkCommands;

namespace CoachingPlan.ApplicationService
{
    public class MarkApplicationService : BaseApplicationService, IMarkApplicationService
    {
        private IMarkRepository _repository;
        private IJobApplicationService _serviceJob;

        public MarkApplicationService(IMarkRepository repository, IJobApplicationService serviceJob ,IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._serviceJob = serviceJob;
        }
        public Mark Create(CreateMarkCommand command)
        {
            var service = new Mark(command.Term, command.Job, command.Description);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public List<Mark> AddToObjective(dynamic body)
        {
            List<Mark> listMark = new List<Mark>();
            foreach (var item in body)
            {
                var listJob = _serviceJob.AddJobs(item.job);
                if ((item.term != null) || (item.term != ""))
                {
                    if (item.id != null)
                        listMark.Add(
                            Update(new UpdateMarkCommand(
                            Guid.Parse((string)item.id),
                            listJob,
                            (DateTime)item.term,
                            (string)item.description)));
                    else
                        listMark.Add(new Mark(
                            (DateTime)item.term,
                            listJob,
                            (string)item.description));
                }
                if (item.id != null)
                    _serviceJob.CheckJobRemovedOfMark(listJob, Guid.Parse((string)item.id));
            }
            return listMark;
        }

        public void CheckMarkRemoved(List<Mark> listMark, Guid idObjective)
        {
            var oldList = _repository.GetAllByObjective(idObjective);
            foreach (var mark in oldList)
            {
                if (!listMark.Contains(mark))
                {
                    _repository.Delete(mark);
                }
            }
        }

        public Mark Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Mark> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Mark> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Mark GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Mark> GetAllByObjective(Guid idObjective)
        {
            return _repository.GetAllByObjective(idObjective);
        }
        public Mark Update(UpdateMarkCommand command)
        {
            var Mark = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Description))
                Mark.ChangeDescription(command.Description);
            if (command.Term != null)
                Mark.ChangeTerm(command.Term);

            if (command.Job != null)
            {
                foreach (var job in command.Job)
                {
                    Mark.AddJob(job);
                }
            }

            _repository.Update(Mark);

            if (Commit())
                return Mark;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
