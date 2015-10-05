using CoachingPlan.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Commands.UserCommands;
using CoachingPlan.Domain.Contracts.Repositories;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CoachingPlan.ApplicationService
{
    public class RoleApplicationService : BaseApplicationService, IRoleApplicationService
    {
        private IRoleRepository _repository;
        public RoleApplicationService(IRoleRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }

        public void create(string name)
        {
            IdentityRole role = new IdentityRole { Name = name };
            _repository.Create(role);
        }
        public IdentityRole GetOne(string id)
        {
            return _repository.GetOne(id);
        }
        public IdentityRole GetOneByName(string name)
        {
            return _repository.GetOneByName(name);
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
