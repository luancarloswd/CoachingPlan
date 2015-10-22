using CoachingPlan.Domain.Commands.MarkCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IMarkApplicationService : IDisposable
    {
        Mark GetOne(Guid id);
        List<Mark> GetAll();
        List<Mark> GetAllByObjective(Guid idObjective);
        List<Mark> GetAll(int take, int skip);
        Mark Create(CreateMarkCommand Mark);
        Mark Update(UpdateMarkCommand Mark);
        Mark Delete(Guid idMark);
        List<Mark> AddToObjective(dynamic body);
        void CheckMarkRemoved(List<Mark> listMark, Guid idObjective);
    }
}
