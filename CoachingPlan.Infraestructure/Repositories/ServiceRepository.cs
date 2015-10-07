using CoachingPlan.Domain.Models;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class ServiceRepository : IWeaknessRepository
    {
        AppDataContext _context;
        public WeaknessRepository(AppDataContext context)
        {
            this._context = context;
        }
       
        public void Dispose()
        {
            _context = null;
        }
    }
}
