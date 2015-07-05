using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Objetivo
    {
        public Objetivo()
        {
            this.Meta = new HashSet<Meta>();
        }

        public int ID_OBJETIVO { get; set; }
        public string DESCRICAO_OBJETIVO { get; set; }
        public int ID_PLANO_ACAO { get; set; }

        public virtual Plano_Acao Plano_Acao { get; set; }
        public virtual ICollection<Meta> Meta { get; set; }
    }
}
