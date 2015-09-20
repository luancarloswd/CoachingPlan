using CoachingPlan.Domain.Scopes;
using System;

namespace CoachingPlan.Domain.Models
{
    public class Phone
    {
        #region Ctor
        protected Phone (){ }
        public Phone(string ddd, string number,string description = null)
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
        public Guid IdPerson { get; set; }
        public virtual Person Person { get; set; }
        #endregion
        
        #region Methods
        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void ChangeDDD(string ddd)
        {
            if (!this.ChangeDDDScopeIsValid(ddd))
                return;
            this.DDD = ddd;
        }
        public void ChangeNumber(string number)
        {
            if (!this.ChangeNumberScopeIsValid(number))
                return;
            this.Number = number;
        }
        public void Validate()
        {
            if (!this.CreatePhoneScopeIsValid())
                return;
        }

        #endregion

    }
}
