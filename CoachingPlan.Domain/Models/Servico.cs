using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Servico
    {
        public Servico()
        {
            this.Processo_Coaching = new HashSet<Processo_Coaching>();
        }

        public int ID_SERVICO { get; set; }
        public string NOME_SERVICO { get; set; }
        public float PRECO_SERVICO { get; set; }
        public string DESC_SERVICO { get; set; }
        public virtual ICollection<Processo_Coaching> Processo_Coaching { get; set; }
    }
}
