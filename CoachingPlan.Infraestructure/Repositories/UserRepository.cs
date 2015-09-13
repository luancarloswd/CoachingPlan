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

namespace CoachingPlan.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context;
        private ApplicationUserManager _userManager;

        public UserRepository(AppDataContext context, ApplicationUserManager userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public void Create(User user, string password)
        {
            IdentityResult addUserResult  = _userManager.CreateAsync(user, password).Result;
            if(!addUserResult.Succeeded){
                foreach (var error in addUserResult.Errors)
                new DomainNotification("AssertArgumentLength", error);
            }
        }

        public void Delete(User user)
        {
            IdentityResult deleteUserResult = _userManager.DeleteAsync(user).Result;
            if (!deleteUserResult.Succeeded)
            {
                foreach (var error in deleteUserResult.Errors)
                    new DomainNotification("AssertArgumentLength", error);
            }
        }
        public List<User> GetAll()
        {
            return _userManager.Users.ToList();
        }

        public List<User> GetAll(int take, int skip)
        {
            return _userManager.Users.OrderBy(x => x.UserName).Skip(skip).Take(take).ToList();
        }

        public async Task<User> GetOne(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
        public async Task<User> GetOneByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<User> GetOneByName(string name)
        {
            return await _userManager.FindByNameAsync(name);
        }
        public User GetOneByPerson(Guid idPerson)
        {
            return _context.Users.Where(UserSpecs.GetOneByPerson(idPerson)).FirstOrDefault();
        }
        public void Update(User user)
        {
            _userManager.UpdateAsync(user);
        }
        public User Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            this._userManager = null;
            this._context = null;
        }
    }
}
