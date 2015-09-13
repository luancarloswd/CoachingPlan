﻿using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class CoacheeRepository : ICoacheeRepository
    {
        AppDataContext _context;
        public CoacheeRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Coachee coachee)
        {
            _context.Coachee.Add(coachee);
        }

        public void Delete(Coachee coachee)
        {
            _context.Coachee.Remove(coachee);
        }

        public List<Coachee> GetAll()
        {
            return _context.Coachee.ToList();
        }

        public List<Coachee> GetAll(int take, int skip)
        {
            return _context.Coachee.OrderBy(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public Coachee GetOne(Guid id)
        {
            return _context.Coachee.Where(CoacheeSpecs.GetOne(id)).FirstOrDefault();
        }

        public Coachee GetOneByUser(string idUser)
        {
            return _context.Coachee.Where(CoacheeSpecs.GetOneByUser(idUser)).FirstOrDefault();
        }

        public void Update(Coachee coachee)
        {
            _context.Entry<Coachee>(coachee).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
