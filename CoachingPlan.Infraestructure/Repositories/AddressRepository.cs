using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Specs;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        AppDataContext _context;
        public AddressRepository(AppDataContext context)
        {
            this._context = context;
        }
        public void Create(Address Address)
        {
            _context.Address.Add(Address);
        }

        public void Delete(Address Address)
        {
            _context.Address.Remove(Address);
        }

        public List<Address> GetAll()
        {
            return _context.Address.ToList();
        }

        public List<Address> GetAll(int take, int skip)
        {
            return _context.Address.OrderBy(x => x.State).Skip(skip).Take(take).ToList();
        }

        public Address GetOne(Guid id)
        {
            return _context.Address.Where(AddressSpecs.GetOne(id)).FirstOrDefault();
        }

        public Address GetOneByPerson(Guid idPerson)
        {
            return _context.Address.Where(AddressSpecs.GetOneByPerson(idPerson)).FirstOrDefault();
        }
        public List<Address> GetAllByPerson(Guid idPerson)
        {
            return _context.Address.Where(AddressSpecs.GetOneByPerson(idPerson)).ToList();
        }
        public void Update(Address Address)
        {
            _context.Entry<Address>(Address).State = System.Data.Entity.EntityState.Modified;
        }
        public void Dispose()
        {
            _context = null;
        }

    }
}
