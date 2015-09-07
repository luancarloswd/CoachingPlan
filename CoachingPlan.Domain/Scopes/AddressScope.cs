using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using CoachingPlan.SharedKernel.Messages;
using CoachingPlan.SharedKernel.Validations;

namespace CoachingPlan.Domain.Scopes
{
    public static class AddressScope
    {
        public static bool CreateAddressScopeIsValid(this Address address)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(address.CEP, Errors.InvalidCEP),
                            AssertionConcern.AssertArgumentLength(address.CEP, 8, 8, Errors.InvalidCEP),
                            CEPAssertionConcern.AssertIsValid(address.CEP, Errors.InvalidCEP),
                            AssertionConcern.AssertArgumentNotNull(address.State, Errors.InvalidState),
                            AssertionConcern.AssertArgumentNotNull(address.City, Errors.InvalidCity),
                            AssertionConcern.AssertArgumentLength(address.City, 3, 35, Errors.InvalidCity),
                            AssertionConcern.AssertArgumentNotNull(address.Street, Errors.InvalidStreet),
                            AssertionConcern.AssertArgumentLength(address.Street, 3, 70, Errors.InvalidStreet),
                            AssertionConcern.AssertArgumentNotNull(address.Number, Errors.InvalidNumber),
                            AssertionConcern.AssertArgumentNotNull(address.Type, Errors.InvalidAddresType)
                );
        }
        public static bool ChangeNumberScopeIsValid(this Address address, int number)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(number, Errors.InvalidNumber)
                );
        }
        public static bool ChangeStreetScopeIsValid(this Address address, string street)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(street, Errors.InvalidStreet),
                            AssertionConcern.AssertArgumentLength(street, 3, 70, Errors.InvalidStreet)
                );
        }
        public static bool ChangeCityScopeIsValid(this Address address, string city)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(city, Errors.InvalidCity),
                            AssertionConcern.AssertArgumentLength(city, 3, 35, Errors.InvalidCity)
                );
        }
        public static bool ChangeStateScopeIsValid(this Address address, EStates state)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(state, Errors.InvalidState)
                );
        }
        public static bool ChangeTypeScopeIsValid(this Address address, EAddressType type)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(type, Errors.InvalidAddresType)
                );
        }
        public static bool ChangeCEPScopeIsValid(this Address address, string cep)
        {
            return AssertionConcern.IsSatisfiedBy(
                            AssertionConcern.AssertArgumentNotNull(cep, Errors.InvalidCEP),
                            AssertionConcern.AssertArgumentLength(cep, 8, 8, Errors.InvalidCEP),
                            CEPAssertionConcern.AssertIsValid(cep, Errors.InvalidCEP)
                );
        }
    }
}
