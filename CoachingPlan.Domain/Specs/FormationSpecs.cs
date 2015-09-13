﻿using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class FormationSpecs
    {
        public static Expression<Func<Formation, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<Formation, bool>> GetOneByCoach(Guid idCoach)
        {
            return x => x.IdCoach == idCoach;
        }
    }
}
