using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        AppDataContext _context;
        public JobRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Job Job)
        {
            _context.Job.Add(Job);
        }

        public void Delete(Job Job)
        {
            _context.Job.Remove(Job);
        }

        public List<Job> GetAll()
        {
            return _context.Job.ToList();
        }

        public List<Job> GetAll(int take, int skip)
        {
            return _context.Job.OrderBy(x => x.Description).Skip(skip).Take(take).ToList();
        }

        public Job GetOne(Guid id)
        {
            return _context.Job.Where(JobSpecs.GetOne(id)).FirstOrDefault();
        }

        public Job GetOneIncludeMark(Guid id)
        {
            return _context.Job.Where(JobSpecs.GetOne(id)).Include(x => x.Mark).FirstOrDefault();
        }

        public void Update(Job Job)
        {
            _context.Entry<Job>(Job).State = EntityState.Modified;
        }

        public List<Job> GetAllByMark(Guid idMark)
        {
            return _context.Job.Where(x => x.IdMark == idMark).ToList();
        }

        public List<Job> GetAllBySession(Guid idSession)
        {
            return _context.Job.Where(x => x.IdSession == idSession).ToList();
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
