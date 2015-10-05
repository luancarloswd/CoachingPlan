using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Infraestructure.Identity;
using Microsoft.AspNet.Identity;
using CoachingPlan.SharedKernel.Events;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Domain.Contracts.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoachingPlan.Infraestructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private AppDataContext _context;
        private ApplicationRoleManager _roleManager;

        public RoleRepository(AppDataContext context, ApplicationRoleManager roleManager)
        {
            this._context = context;
            this._roleManager = roleManager;
        }

        public void Create(IdentityRole role)
        {
            var result =  _roleManager.Create(role);
            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    new DomainNotification("AssertArgumentLength", error);
            }
        }

        public IdentityRole GetOne(string id)
        {
            return _roleManager.FindById(id);
        }

        public IdentityRole GetOneByName(string name)
        {
            return _roleManager.FindByName(name);
        }

        public void Dispose()
        {
            //this._userManager = null;
            //this._context = null;
        }


    }
}
