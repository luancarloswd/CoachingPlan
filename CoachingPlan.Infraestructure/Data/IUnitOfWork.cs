using System;

namespace CoachingPlan.Infraestructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}