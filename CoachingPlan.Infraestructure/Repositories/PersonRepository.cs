using System;
using System.Collections.Generic;
using System.Linq;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Domain.Contracts.Repositories;
using System.Data.Entity;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        AppDataContext _context;
        public PersonRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Person Person)
        {
            _context.Person.Add(Person);
        }

        public void Delete(Person Person)
        {
            _context.Person.Remove(Person);
        }

        public List<Person> GetAll()
        {
            return _context.Person.ToList();
        }
        public Person GetOneIncludeDetails(Guid id)
        {
            return _context.Person.Include(x => x.Address).Include(x => x.Phone).FirstOrDefault(x=> x.Id == id);
        }
        public List<Person> GetAllIncludeDetails()
        {
            return _context.Person.Include(x=>x.User).Include(x => x.Address).Include(x => x.Phone).ToList();
        }

        public List<Person> GetAll(int take, int skip)
        {
            return _context.Person.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public List<Person> GetAllByNameIncludeCoach(string name)
        {
            return _context.Person.Where(x => x.Name == name).Include(x => x.User).Include(x => x.User.Select(y => y.Coach)).ToList();
        }

        public List<Person> GetAllByNameIncludeCoachee(string name)
        {
            return _context.Person.Where(x => x.Name == name).Include(x => x.User).Include(x => x.User.Select(y => y.Coachee)).ToList();
        }

        public Person GetOne(Guid id)
        {
            return _context.Person.Where(PersonSpecs.GetOne(id)).FirstOrDefault();
        }

        public Person GetOneByPerson(Guid idPerson)
        {
            return _context.Person.Where(PersonSpecs.GetOne(idPerson)).FirstOrDefault();
        }

        public void Update(Person Person)
        {
            _context.Entry<Person>(Person).State = EntityState.Modified;
        }
        public void Dispose()
        {

        }
    }
}
