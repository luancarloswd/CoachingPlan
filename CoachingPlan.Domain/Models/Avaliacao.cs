using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Avaliacao
    {
        public int ID_AVALIACAO { get; set; }
        public int ID_SESSAO { get; set; }
        public string ID_USUARIO { get; set; }
        public float NOTA_AVALIACAO { get; set; }
        public string OBSERVACAO_AVALIACAO { get; set; }

        public virtual Sessao Sessao { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
