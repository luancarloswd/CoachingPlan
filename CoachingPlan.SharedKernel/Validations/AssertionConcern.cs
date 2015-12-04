using CoachingPlan.SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoachingPlan.SharedKernel.Validations
{
    public class AssertionConcern
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

        public static DomainNotification AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
        {
            int length = stringValue.Trim().Length;

            return (length < minimum || length > maximum) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AssertArgumentMatches(string pattern, string stringValue, string message)
        {
            Regex regex = new Regex(pattern);

            return (!regex.IsMatch(stringValue)) ?
                new DomainNotification("AssertArgumentLength", message) : null;
        }

        public static DomainNotification AsserArgumenttNotEmpty(string stringValue, string message)
        {
            return (string.IsNullOrEmpty(stringValue)) ?
                new DomainNotification("AssertArgumentNotEmpty", message) : null;
        }

        public static DomainNotification AssertArgumentNotNull(object object1, string message)
        {

            return (object1 == null) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

        public static DomainNotification AssertArgumentTrue(bool boolValue, string message)
        {
            return (!boolValue) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertArgumentAreEquals(string value, string match, string message)
        {
            return (!(value == match)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AsserArgumenttIsGreaterThan(int value1, int value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertArgumentIsGreaterThan(decimal value1, decimal value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }

        public static DomainNotification AssertArgumentIsGreaterOrEqualThan(int value1, int value2, string message)
        {
            return (!(value1 >= value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
        public static DomainNotification AssertArgumentIsGreaterOrEqualThan(DateTime value1, DateTime value2, string message)
        {
            return (!(value1 >= value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
        public static DomainNotification AssertArgumentIsGreaterThan(DateTime value1, DateTime value2, string message)
        {
            return (!(value1 > value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
        public static DomainNotification AssertArgumentAreEquals(DateTime value1, DateTime value2, string message)
        {
            return (!(value1 == value2)) ?
                new DomainNotification("AssertArgumentTrue", message) : null;
        }
        public static DomainNotification CEPIsValid(string cep, string message)
        {
            if (cep.Length == 8)
            {
                cep = cep.Substring(0, 5) + "-" + cep.Substring(5, 3);
            }
            return (!System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"))) ?
                new DomainNotification("AssertArgumentNotNull", message) : null;
        }

    }
}