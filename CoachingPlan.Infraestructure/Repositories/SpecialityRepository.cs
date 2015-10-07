using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        AppDataContext _context;
        public SpecialityRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Speciality Speciality)
        {
            _context.Speciality.Add(Speciality);
        }

        public void Delete(Speciality Speciality)
        {
            _context.Speciality.Remove(Speciality);
        }

        public List<Speciality> GetAll()
        {
            return _context.Speciality.ToList();
        }

        public List<Speciality> GetAll(int take, int skip)
        {
            return _context.Speciality.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public Speciality GetOne(Guid id)
        {
            return _context.Speciality.Where(SpecialitySpecs.GetOne(id)).FirstOrDefault();
        }

        public Speciality GetOneByCoach(Guid idCoach)
        {
            return _context.Speciality.Where(SpecialitySpecs.GetOneByCoach(idCoach)).FirstOrDefault();
        }

        public List<Speciality> GetAllByCoach(Guid idCoach)
        {
            return _context.Speciality.Where(SpecialitySpecs.GetOneByCoach(idCoach)).ToList();
        }

        public void Update(Speciality Speciality)
        {
            _context.Entry<Speciality>(Speciality).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
