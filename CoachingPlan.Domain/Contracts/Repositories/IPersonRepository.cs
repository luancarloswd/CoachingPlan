﻿using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace PersoningPlan.Domain.Contracts.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        Person GetOne(Guid id);
        List<Person> GetAll();
        List<Person> GetAll(int take, int skip);
        void Create(Person Person);
        void Update(Person Person);
        void Delete(Person Person);
    }
}