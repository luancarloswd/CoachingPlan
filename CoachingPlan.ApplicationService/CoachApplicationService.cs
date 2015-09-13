﻿using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.CoachCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class CoachApplicationService : BaseApplicationService, ICoachApplicationService
    {
        private ICoachRepository _repository;

        public CoachApplicationService(ICoachRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Coach Create(CreateCoachCommand command)
        {
            var coach = new Coach(command.IdUser,command.EvaluationTool, command.Speciality, command.Formation, command.CoachingProcess);
            _repository.Create(coach);

            if (Commit())
                return coach;

            return null;
        }

        public Coach Delete(Guid id)
        {
            var Coach = _repository.GetOne(id);
            _repository.Delete(Coach);

            if (Commit())
                return Coach;

            return null;
        }

        public List<Coach> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Coach> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Coach GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public Coach GetOneByUser(string idUser)
        {
            return _repository.GetOneByUser(idUser);
        }
        public Coach Update(Coach coach)
        {
            _repository.Update(coach);

            if (Commit())
                return coach;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}