using System;
using System.Collections.Generic;

namespace CoachingPlan.SharedKernel
{
    public interface IContainer
    {
        object GetService(Type serviceType);
        IEnumerable<T> GetService<T>();
        IEnumerable<object> GetServices(Type serviceType);
    }
}
