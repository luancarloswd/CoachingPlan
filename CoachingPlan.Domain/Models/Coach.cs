using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Coach
    {
        #region Ctor
        //protected Coach(){}
        public Coach()
        {
            this.Id = Guid.NewGuid();
            //this.Ferramenta_Avaliacao = new HashSet<Ferramenta_Avaliacao>();
            this.Especialidade = new HashSet<Especialidade>();
            this.Formacao = new HashSet<Formacao>();
            //this.Processo_Coaching = new HashSet<Processo_Coaching>();
        }
        #endregion
        #region Properties
        public Guid Id { get; private set; }
        //public virtual ICollection<Ferramenta_Avaliacao> Ferramenta_Avaliacao { get; set; }
        public virtual ICollection<Especialidade> Especialidade { get; set; }
        public virtual ICollection<Formacao> Formacao { get; set; }
        public virtual Usuario Usuario { get; set; }
        //public virtual ICollection<Processo_Coaching> Processo_Coaching { get; set; }
        #endregion
        #region Methods
        #endregion
    }
}
