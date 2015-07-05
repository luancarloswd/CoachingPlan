using CoachingPlan.Resources.Messages;
using System;

namespace CoachingPlan.Resources.Validations
{
    public class CEPAssertionConcern
    {
        public static void AssertIsValid(string cep)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            if(!System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}")))
                throw new Exception(Errors.InvalidCEP);
        }
    }
}
