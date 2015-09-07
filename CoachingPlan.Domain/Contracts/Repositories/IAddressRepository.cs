﻿using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IAddressRepository : IDisposable
    {
        Address GetOne(Guid id);
        List<Address> GetAll();
        List<Address> GetAll(int take, int skip);
        void Create(Address AcctionPlan);
        void Update(Address Coachee);
        void Delete(Address Coachee);
    }
}
