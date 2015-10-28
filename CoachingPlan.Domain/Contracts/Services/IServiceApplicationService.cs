using CoachingPlan.Domain.Commands.ServiceCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IServiceApplicationService : IDisposable
    {
        Service GetOne(Guid id);
        List<Service> GetAll();
        List<Service> GetAll(int take, int skip);
        Service Create(CreateServiceCommand command);
        Service Update(UpdateServiceCommand command);
        Service Delete(Guid idService);
        List<Service> GetAllByCoachingProcess(Guid idCoachingProcess);
        List<Service> AddToCoachingProcess(dynamic body);
        CoachingProcess CheckServiceRemoved(List<Service> listService, CoachingProcess coachingProcess);
        Service GetOneIncludeCoachingProcess(Guid iddCoachingProcess);
        Service GetOneByName(string name);
    }
}
