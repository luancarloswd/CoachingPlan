using CoachingPlan.Domain.Commands.WeaknessCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IWeaknessApplicationService : IDisposable
    {
        Weakness GetOne(Guid id);
        Weakness GetOnebyCoachee(Guid idCoachee);
        List<Weakness> GetAll();
        List<Weakness> GetAll(int take, int skip);
        Weakness Create(CreateWeaknessCommand Weakness);
        Weakness Update(ChangeWeaknessCommand Weakness);
        Weakness Delete(Guid id);
        List<Weakness> AddToCoachee(dynamic body);
    }
}
