using CoachingPlan.Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IRoleRepository : IDisposable
    {
        void Create(IdentityRole role);
        IdentityRole GetOne(string id);
        IdentityRole GetOneByName(string name);
    }
}
