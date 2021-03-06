﻿using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class ServiceApplicationService : BaseApplicationService, IServiceApplicationService
    {
        private IServiceRepository _repository;

        public ServiceApplicationService(IServiceRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Service Create(CreateServiceCommand command)
        {
            var service = new Service(command.Name, command.Value, command.CoachingProcess, command.Description);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public Service Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Service> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Service> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Service GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Service> GetAllByCoachingProcess(Guid idCoachingProcess)
        {
            return _repository.GetAllByCoachingProcess(idCoachingProcess);
        }
        public Service Update(UpdateServiceCommand command)
        {
            var service = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Name))
                service.ChangeName(command.Name);
            if (!string.IsNullOrEmpty(command.Description))
                service.changeDescripion(command.Description);

            service.ChangeValue(command.Value);

            _repository.Update(service);

            if (Commit())
                return service;

            return null;
        }

        public Service GetOneByName(string name)
        {
            return _repository.GetOneByName(name);
        }

        public Service GetOneIncludeCoachingProcess(Guid id)
        {
            return _repository.GetOneIncludeCoachingProcess(id);
        }
        public List<Service> AddToCoachingProcess(dynamic body)
        {
            List<Service> listService = new List<Service>();
            foreach (var item in body)
            {
                    listService.Add(GetOneIncludeCoachingProcess(Guid.Parse((string)item.id)));
            }

            return listService;
        }

        public CoachingProcess CheckServiceRemoved(List<Service> listService, CoachingProcess coachingProcess)
        {
            var oldList = _repository.GetAllByCoachingProcess(coachingProcess.Id);
            foreach (var service in oldList)
            {
                if (!listService.Contains(service))
                {
                    coachingProcess.RemoveService(service);
                }
            }
            foreach (var service in listService)
                coachingProcess.AddService(service);
            return coachingProcess;
        }
        public void Dispose()
        {
            _repository = null;
        }

    }
}
