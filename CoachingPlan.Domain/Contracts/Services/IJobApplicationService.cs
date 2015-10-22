using CoachingPlan.Domain.Commands.JobCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IJobApplicationService : IDisposable
    {
        Job GetOne(Guid id);
        List<Job> GetAll();
        List<Job> GetAllByMark(Guid idMark);
        List<Job> GetAll(int take, int skip);
        Job Create(CreateJobCommand Job);
        Job Update(UpdateJobCommand Job);
        Job Delete(Guid idJob);
        List<Job> AddJobs(dynamic body);
        void CheckJobRemovedOfMark(List<Job> listJob, Guid idMark);
        Session CheckJobRemovedOfSession(List<Job> listJob, Session session);
        List<Job> AddJobToSession(dynamic body);
    }
}
