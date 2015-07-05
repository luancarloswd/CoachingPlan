using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Plano_Acao
    {
        public Plano_Acao()
        {
            this.Objetivo = new HashSet<Objetivo>();
        }

        public int ID_PLANO_ACAO { get; set; }
        public int ID_PROCESSO { get; set; }
        public string DESCRICAO_PLANO_ACAO { get; set; }

        public virtual ICollection<Objetivo> Objetivo { get; set; }
        public virtual Processo_Coaching Processo_Coaching { get; set; }
    }
}
