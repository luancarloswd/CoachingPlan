﻿using CoachingPlan.SharedKernel.Messages;
using System;
using System.Text.RegularExpressions;

namespace CoachingPlan.SharedKernel.Validations
{
    class EmailAssertionConcern
    {
        public static void AssertIsValid(string email)
        {
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                throw new Exception(Errors.InvalidEmail);
        }
    }
}
