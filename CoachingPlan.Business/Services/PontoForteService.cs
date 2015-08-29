using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Models;
using CoachingPlan.Resources.Messages;
using System;
using System.Collections.Generic;
namespace CoachingPlan.Business.Services
{
    //public class PontoForteService : IPontoForteService
    //{
    //    private IPontoForteRepository _repository;
    //    public PontoForteService(IPontoForteRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public StrongPoint GetOne(Guid id)
    //    {
    //        var PontoForte = _repository.GetOne(id);
    //        if (PontoForte == null)
    //            throw new Exception(Errors.SpecialtyNotFound);

    //        return PontoForte;
    //    }

    //    public void Register(StrongPoint PontoForte)
    //    {
    //        PontoForte.Validate();

    //        _repository.Create(PontoForte);
    //    }

    //    public void ChageInformation(Guid id, StrongPoint pontoForte)
    //    {
    //        var PontoForte = GetOne(id);

    //        PontoForte.ChangeStrongPoing(pontoForte.Name);
    //        PontoForte.ChangeClass(pontoForte.Class);
    //        PontoForte.ChangeDescription(pontoForte.Description);
    //        PontoForte.Validate();

    //        _repository.Update(PontoForte);
    //    }

    //    public void Remove(Guid id)
    //    {
    //        var PontoForte = GetOne(id);
    //        _repository.Delete(PontoForte);
    //    }
    //    public ICollection<StrongPoint> GetAll()
    //    {
    //        return _repository.GetAll();
    //    }

    //    public void Dispose()
    //    {
    //        _repository.Dispose();
    //    }

    //}
}
