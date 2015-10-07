using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Infraestructure.Identity;
using Microsoft.AspNet.Identity;
using CoachingPlan.SharedKernel.Events;
using CoachingPlan.Domain.Specs;
using CoachingPlan.Domain.Contracts.Repositories;
using System.Security.Claims;

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
            IdentityResult addUserResult  = _userManager.Create(user, password);
            if(!addUserResult.Succeeded){
                foreach (var error in addUserResult.Errors)
                new DomainNotification("AssertArgumentLength", error);
            }
        }
        public void SendEmail(string idUser, string subject, string body)
        {
            var result = _userManager.SendEmailAsync(idUser, subject, body);
        }
        public string GenerateTokenRecoveryPassword(string id)
        {
            return _userManager.GeneratePasswordResetToken(id);
        }
        public void RecoveryPassword(string idUser, string token, string password)
        {   
            IdentityResult addUserResult = _userManager.ResetPassword(idUser, token, password);
            if (!addUserResult.Succeeded)
            {
                foreach (var error in addUserResult.Errors)
                    new DomainNotification("AssertArgumentLength", error);
            }
        }
        public void Delete(User user)
        {
            _context.Person.Remove(user.Person);

            IdentityResult deleteUserResult = _userManager.Delete(user);
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


        public List<User> GetAllIncludeDetails()
        {
            return _userManager.Users.Include(x => x.Roles).Include(x => x.Person).Include(x => x.Person.Phone).Include(x => x.Person.Address).ToList();
        }
        public User GetOneIncludeDetails(string id)
        {
            return _userManager.Users.Include(x => x.Roles).Include(x => x.Person).Include(x => x.Person.Phone).Include(x => x.Person.Address).FirstOrDefault(x => x.Id == id);
        }
        public User GetOne(string id)
        {
            return  _context.Users.FirstOrDefault(x => x.Id == id);
        }
        public User GetOneByEmail(string email)
        {
            return _userManager.FindByEmail(email);
        }
        public User GetOneByEmailIncludePerson(string email)
        {
            return _context.Users.Include(x => x.Person).Include(x => x.Roles).FirstOrDefault(UserSpecs.GetOneByEmail(email));
        }

        public User GetOneByName(string name)
        {
            return _userManager.FindByName(name);
        }
        public User GetOneByPerson(Guid idPerson)
        {
            return _context.Users.Where(UserSpecs.GetOneByPerson(idPerson)).FirstOrDefault();
        }
        public void Update(User user)
        {
            _userManager.UpdateAsync(user);
        }
        public User Authenticate(string userName, string password)
        {
            return  _userManager.Find(userName, password);
        }
        public void AddRole(string id, string role)
        {
             _userManager.AddToRole(id, role);
        }

        public ICollection<string> GetAllRoles(string id)
        {
            return _userManager.GetRoles(id);
        }
        public ClaimsIdentity GenerateUserIdentityAsync(User user, string authenticationType)
        {
            var userIdentity = _userManager.CreateIdentity(user, authenticationType);
            return userIdentity;
        }
        public void Dispose()
        {
            //this._userManager = null;
            //this._context = null;
        }


    }
}
