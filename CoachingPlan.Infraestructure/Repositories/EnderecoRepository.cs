using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    //public class EnderecoRepository : IEnderecoRepository
    //{
    //    private AppDataContext _context;

    //    public EnderecoRepository(AppDataContext context)
    //    {
    //        this._context = context;
    //    }
    //    public Address GetOne(Guid id)
    //    {
    //        return _context.Endereco.Where(x => x.Id == id).FirstOrDefault();
    //    }

    //    public List<Address> GetAll()
    //    {
    //        return _context.Endereco.ToList();
    //    }

    //    public void Create(Address Endereco)
    //    {
    //        _context.Endereco.Add(Endereco);
    //        _context.SaveChanges();
    //    }

    //    public void Update(Address Endereco)
    //    {
    //        _context.Entry<Address>(Endereco).State = EntityState.Modified;
    //        _context.SaveChanges();
    //    }

    //    public void Delete(Address Endereco)
    //    {
    //        _context.Endereco.Remove(Endereco);
    //        _context.SaveChanges();
    //    }

    //    public void Dispose()
    //    {
    //        _context.Dispose();
    //    }
    //}
}
