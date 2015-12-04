using CoachingPlan.SharedKernel.Events;
using CoachingPlan.SharedKernel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoachingPlan.SharedKernel.Validations
{
    public class CEPAssertionConcern
    {
        public static bool IsSatisfiedBy(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }
        public static DomainNotification AssertIsValid(string cep, string message)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            return (!System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}")))?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }
    }
}
