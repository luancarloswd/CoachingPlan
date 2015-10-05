using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Contracts.Repositories;
using System.Security.Claims;

namespace CoachingPlan.ApplicationService
{
    public class UserApplicationService : BaseApplicationService, IUserApplicationService
    {
        private IUserRepository _repository;
        public UserApplicationService(IUserRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public User Create(CreateUserCommand commandUser)
        {
            var user = new User(commandUser.IdPerson, commandUser.Email, commandUser.UserName);
            user.Validate();
            _repository.Create(user, commandUser.Password);

            if (Commit())
                return user;

            return null;
        }

        public User Delete(string id)
        {
            var user = _repository.GetOneIncludeDetails(id);
            _repository.Delete(user);

            if (Commit())
                return user;

            return null;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public List<User> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public List<User> GetAllIncludeDetails()
        {
            return _repository.GetAllIncludeDetails();
        }

        public User GetOne(string id)
        {
            return _repository.GetOne(id);
        }

        public User GetOneByEmail(string email)
        {
            return _repository.GetOneByEmail(email);
        }

        public User GetOneByName(string name)
        {
            return _repository.GetOneByName(name);
        }
        public User GetOneByPerson(Guid idPerson)
        {
            return _repository.GetOneByPerson(idPerson);
        }
        public User Authenticate(string userName, string password)
        {
            return _repository.Authenticate(userName, password);
        }
        public User Update(UpdateUserCommand commandUser)
        {
            var userInto = new User(commandUser.IdPerson, commandUser.Email, commandUser.UserName);
            userInto.Validate();

            _repository.Update(userInto);

            if (Commit())
                return userInto;

            return null;
        }
        public void AddRole(string id, string role)
        {
            _repository.AddRole(id, role);
        }

        public ICollection<string> GetAllRoles(string id)
        {
            return _repository.GetAllRoles(id);
        }

        public ClaimsIdentity GenerateUserIdentityAsync(User user, string authenticationType)
        {
            return _repository.GenerateUserIdentityAsync(user, authenticationType);
        }

        public User GetOneByEmailIncludePerson(string email)
        {
            return _repository.GetOneByEmailIncludePerson(email);
        }
        public User GetOneIncludeDetails(string id)
        {
            return _repository.GetOneIncludeDetails(id);
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
