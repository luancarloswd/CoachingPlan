using CoachingPlan.Resources.Messages;
using CoachingPlan.Resources.Validations;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Phone
    {
        #region Ctor
        protected Phone (){ }
        public Phone(string ddd, string number, string description = null)
        {
            this.Id = Guid.NewGuid();
            this.DDD = ddd;
            this.Number = number;
            this.Description = description;
        }
        #endregion

        #region Properties
        public Guid Id { get; private set; }
        public string DDD { get; private set; }
        public string Number { get; private set; }
        public string Description { get; private set; }
        public virtual People People { get; set; }
        #endregion
        
        #region Methods
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void ChangeDDD(string DDD)
        {
            this.DDD = DDD;
        }
        public void ChangeNumber(string number)
        {
            this.Number = number;
        }
        public void Validate()
        {
            AssertionConcern.AssertArgumentNotNull(this.DDD, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentLength(this.DDD, 2, 2, Errors.InvalidDDD);
            AssertionConcern.AssertArgumentNotNull(this.Number, Errors.InvalidTelefone);
            AssertionConcern.AssertArgumentLength(this.Number, 8, 8, Errors.InvalidTelefone);
        }

        #endregion

    }
}
