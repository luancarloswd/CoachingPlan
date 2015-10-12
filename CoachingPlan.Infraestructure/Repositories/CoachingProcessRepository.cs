﻿using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class CoachingProcessRepository : ICoachingProcessRepository
    {
        AppDataContext _context;
        public CoachingProcessRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(CoachingProcess coachingProcess)
        {
            _context.CoachingProcess.Add(coachingProcess);
        }

        public void Delete(CoachingProcess coachingProcess)
        {
            _context.CoachingProcess.Remove(coachingProcess);
        }

        public List<CoachingProcess> GetAll()
        {
            return _context.CoachingProcess.ToList();
        }

        public CoachingProcess GetOneIncludeDetails(Guid id)
        {
            return _context.CoachingProcess.Include(x => x.Coachee.Select(n => n.User)).Include(x => x.Coachee.Select(n => n.User.Person)).Include(x => x.Coach.Select(n => n.User)).Include(x => x.Coach.Select(n => n.User.Person)).Include(x => x.Coachee).Include(x => x.Coach).Include(x => x.PerformanceIndicator).Include(x => x.Budget).Include(x => x.Session).Include(x => x.Service).FirstOrDefault(x => x.Id == id);
        }

        public List<CoachingProcess> GetAll(int take, int skip)
        {
            return _context.CoachingProcess.OrderBy(x => x.StartDate).Skip(skip).Take(take).ToList();
        }

        public CoachingProcess GetOne(Guid id)
        {
            return _context.CoachingProcess.Where(CoachingProcessSpecs.GetOne(id)).FirstOrDefault();
        }

        public List<CoachingProcess> GetAllByService(Guid idService)
        {
            return _context.CoachingProcess.Where(x => x.Service.FirstOrDefault(y => y.Id == idService).Id == idService).ToList();
        }

        public void Update(CoachingProcess coachingProcess)
        {
            _context.Entry<CoachingProcess>(coachingProcess).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
