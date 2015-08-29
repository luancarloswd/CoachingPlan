using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Phone
    {
        #region Ctor
        protected Phone (){ }
        public Phone(string ddd, string number, Person person, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.DDD = ddd;
            this.Number = number;
            this.Person = person;
            this.IdPerson = person.Id;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string DDD { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }
        public Guid IdPerson { get; set; }
        public virtual Person Person { get; set; }
        #endregion
        
        #region Methods
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void ChangeDDD(string DDD)
        {
            this.DDD = DDD;
            this.Validate();
        }
        public void ChangeNumber(string number)
        {
            this.Number = number;
            this.Validate();
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.DDD, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentLength(this.DDD, 2, 2, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentNotNull(this.Number, Errors.InvalidPhone);
            AssertionConcern.AssertArgumentLength(this.Number, 8, 8, Errors.InvalidPhone);
        }

        #endregion

    }
}
