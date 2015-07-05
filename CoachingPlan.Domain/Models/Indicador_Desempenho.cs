using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Indicador_Desempenho
    {
        public int ID_INDICADOR { get; set; }
        public int ID_PROCESSO { get; set; }
        public string INDICADOR { get; set; }

        public virtual Processo_Coaching Processo_Coaching { get; set; }
    }
}
