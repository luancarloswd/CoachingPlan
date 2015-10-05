using CoachingPlan.Domain.Commands.AddressCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IAddressApplicationService : IDisposable
    {
        Address GetOne(Guid id);
        Address GetOnebyPerson(Guid idPerson);
        List<Address> GetAll();
        List<Address> GetAll(int take, int skip);
        Address Create(CreateAddressCommand Address);
        Address Update(ChangeAddressCommand Address);
        Address Delete(Guid id);
        List<Address> AddToPerson(dynamic address);
    }
}
