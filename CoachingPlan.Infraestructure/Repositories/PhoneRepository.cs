using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Specs;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        AppDataContext _context;
        public PhoneRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Phone phone)
        {
            _context.Phone.Add(phone);
        }

        public void Delete(Phone phone)
        {
            _context.Phone.Remove(phone);
        }

        public List<Phone> GetAll()
        {
            return _context.Phone.ToList();
        }

        public List<Phone> GetAll(int take, int skip)
        {
            return _context.Phone.OrderBy(x => x.DDD).Skip(skip).Take(take).ToList();
        }

        public Phone GetOne(Guid id)
        {
            return _context.Phone.Where(PhoneSpecs.GetOne(id)).FirstOrDefault();
        }

        public Phone GetOnebyPerson(Guid idPerson)
        {
            return _context.Phone.Where(PhoneSpecs.GetOneByPerson(idPerson)).FirstOrDefault();
        }

        public List<Phone> GetAllbyPerson(Guid idPerson)
        {
            return _context.Phone.Where(PhoneSpecs.GetOneByPerson(idPerson)).ToList();
        }

        public void Update(Phone phone)
        {
            _context.Entry<Phone>(phone).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }
    }
}
