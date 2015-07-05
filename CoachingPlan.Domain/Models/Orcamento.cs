using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Orcamento
    {
        public int ID_PROPOSTA { get; set; }
        public int ID_PROCESSO { get; set; }
        public string PROPOSTA { get; set; }
        public float PRECO_PROPOSTA { get; set; }
        public System.DateTime DATA_PROPOSTA { get; set; }
        public float PRECO_SESSAO { get; set; }

        public virtual Processo_Coaching Processo_Coaching { get; set; }
    }
}
