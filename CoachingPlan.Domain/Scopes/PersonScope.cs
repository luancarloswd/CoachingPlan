using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;
using System;

namespace CoachingPlan.Domain.Scopes
{
    public static class PersonScope
    {
        public static bool CreatePersonScopeIsValid(this Person person)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(person.Name, Errors.InvalidName),
                            AssertionConcern.AssertArgumentLength(person.Name, 4, 65, Errors.InvalidName),
                            CPFAssertionConcern.AssertIsValid(person.CPF, Errors.InvalidCPF),
                            AssertionConcern.AssertArgumentNotNull(person.CPF, Errors.InvalidCPF),
                            AssertionConcern.AssertArgumentLength(person.CPF, 11, 11, Errors.InvalidCPF),
                            AssertionConcern.AssertArgumentNotNull(person.BirthDate, Errors.InvalidBirthDate),
                            AssertionConcern.AssertArgumentIsGreaterThan(DateTime.Now, person.BirthDate, Errors.InvalidBirthDate),
                            AssertionConcern.AssertArgumentNotNull(person.Genre, Errors.InvalidGenre),
                            AssertionConcern.AssertArgumentNotNull(person.Status, Errors.InvalidStatus)
                );
        }
        public static bool ChangeStatusScopeIsValid(this Person person, bool status)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(status, Errors.InvalidStatus)
                );
        }
        public static bool ChangeGenreScopeIsValid(this Person person, EGenre genre)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(genre, Errors.InvalidGenre)
                );
        }
        public static bool ChangeBirthDatedScopeIsValid(this Person person, DateTime birthDate)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(birthDate, Errors.InvalidBirthDate),
                            AssertionConcern.AssertArgumentIsGreaterThan(DateTime.Now, birthDate, Errors.InvalidBirthDate)
                );
        }
        public static bool ChangeCPFScopeIsValid(this Person person, string cpf)
        {
            return AssertionConcern.IsSatisfiedBy(
                            CPFAssertionConcern.AssertIsValid(cpf, Errors.InvalidCPF),
                            AssertionConcern.AssertArgumentNotNull(cpf, Errors.InvalidCPF),
                            AssertionConcern.AssertArgumentLength(cpf, 11, 11, Errors.InvalidCPF)
                );
        }
        public static bool ChangeNameScopeIsValid(this Person person, string name)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(name, Errors.InvalidName),
                            AssertionConcern.AssertArgumentLength(name, 4, 65, Errors.InvalidName)
                );
        }

    }
}
