using CoachingPlan.Domain.Commands.CoachCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface ICoachApplicationService : IDisposable
    {
        Coach GetOne(Guid id);
        Coach GetOneByUser(string idUser);
        List<Coach> GetAll();
        List<Coach> GetAll(int take, int skip);
        Coach Create(CreateCoachCommand commandCoach);
        Coach Update(UpdateCoachCommand command);
        Coach Delete(Guid id);
        List<Coach> GetAllIncludeDetails();
        List<Coach> GetAllIncludePerson();
        Coach GetOneIncludeDetails(Guid id);
        List<Coach> AddCoach(dynamic body);
        CoachingProcess CheckCoachRemovedOfCoachingProcess(List<Coach> listCoachingProcess, CoachingProcess coachingProcess);
        Coach GetOneIncludeCoachingProcess(Guid id);
    }
}
