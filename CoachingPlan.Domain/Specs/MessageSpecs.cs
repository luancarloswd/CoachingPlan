using CoachingPlan.Domain.Models;
using System;
using System.Linq.Expressions;

namespace CoachingPlan.Domain.Specs
{
    public static class MessageSpecs
    {
        public static Expression<Func<Message, bool>> GetOne(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Message, bool>> GetHistory(string idUser, string destination)
        {
            return x => x.IdUser == idUser && x.Destination == destination;
        }
    }
}
