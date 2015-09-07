using CoachingPlan.SharedKernel.Events;
using CoachingPlan.SharedKernel.Messages;
using System;

namespace CoachingPlan.SharedKernel.Validations
{
    public class CEPAssertionConcern
    {
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
