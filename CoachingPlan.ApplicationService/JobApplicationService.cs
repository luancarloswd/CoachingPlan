using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.JobCommands;

namespace CoachingPlan.ApplicationService
{
    public class JobApplicationService : BaseApplicationService, IJobApplicationService
    {
        private IJobRepository _repository;

        public JobApplicationService(IJobRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Job Create(CreateJobCommand command)
        {
            var service = new Job(command.StartDate, command.RealizationDate, command.VerificationDate, command.Description);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public List<Job> AddJobs(dynamic body)
        {
            List<Job> listJob = new List<Job>();
            foreach (var item in body)
            {
                if ((item.startDate != null) || (item.startDate != ""))
                {
                    if (item.id != null)
                        listJob.Add(
                            Update(new UpdateJobCommand(
                            Guid.Parse((string)item.id),
                            (DateTime)item.startDate,
                            (DateTime)item.verificationDate,
                            (DateTime)item.realizationDate,
                            (string)item.description)));
                    else
                        listJob.Add(new Job(
                            (DateTime)item.startDate,
                            (DateTime)item.verificationDate,
                            (DateTime)item.realizationDate,
                            (string)item.description));
                }
            }
            return listJob;
        }

        public List<Job> AddJobToSession(dynamic body)
        {
            List<Job> listJob = new List<Job>();
            foreach (var item in body)
            {
                listJob.Add(GetOne(Guid.Parse((string)item.id)));
            }
            return listJob;
        }

        public void CheckJobRemovedOfMark(List<Job> listJob, Guid idMark)
        {
            var oldList = _repository.GetAllByMark(idMark);
            foreach (var job in oldList)
            {
                if (!listJob.Contains(job))
                {
                    _repository.Delete(job);
                }
            }
        }

        public Session CheckJobRemovedOfSession(List<Job> listJob, Session session)
        {
            var oldList = _repository.GetAllBySession(session.Id);
            foreach (var job in oldList)
            {
                if (!listJob.Contains(job))
                {
                    session.RemoveJob(job);
                }
            }
            foreach (var job in listJob)
                session.AddJob(job);

            return session;
        }

        public Job Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Job> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Job> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Job GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Job> GetAllByMark(Guid idMark)
        {
            return _repository.GetAllByMark(idMark);
        }
        public Job Update(UpdateJobCommand command)
        {
            var Job = _repository.GetOne(command.Id);
            if (command.RealizationDate != null)
                Job.ChangeRealizationDate(command.RealizationDate);
            if (command.StartDate != null)
                Job.ChangeStartDate(command.StartDate);
            if (command.VerificationDate != null)
                Job.ChangeVerifaciontDate(command.VerificationDate);

            _repository.Update(Job);

            if (Commit())
                return Job;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
