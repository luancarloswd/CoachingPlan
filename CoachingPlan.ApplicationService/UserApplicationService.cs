using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Contracts.Repositories;

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
            var user = _repository.GetOne(id);
            _repository.Delete(user.Result);

            if (Commit())
                return user.Result;

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

        public User GetOne(string id)
        {
            return _repository.GetOne(id).Result;
        }

        public User GetOneByEmail(string email)
        {
            return _repository.GetOneByEmail(email).Result;
        }

        public User GetOneByName(string name)
        {
            return _repository.GetOneByName(name).Result;
        }
        public User GetOneByPerson(Guid idPerson)
        {
            return _repository.GetOneByPerson(idPerson);
        }
        public User Update(User user)
        {
            var userInto = user;
            userInto.Validate();

            _repository.Update(userInto);

            if (Commit())
                return userInto;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }

    }
}
