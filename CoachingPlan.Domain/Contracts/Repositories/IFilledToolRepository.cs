using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace FilledToolingPlan.Domain.Contracts.Repositories
{
    public interface IFilledToolRepository : IDisposable
    {
        FilledTool GetOne(Guid id);
        List<FilledTool> GetAll();
        List<FilledTool> GetAll(int take, int skip);
        void Create(FilledTool FilledTool);
        void Update(FilledTool FilledTool);
        void Delete(FilledTool FilledTool);
    }
}
