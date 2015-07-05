using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Resposta
    {
        public int ID_RESPOSTA { get; set; }
        public int ID_QUESTAO { get; set; }
        public string RESPOSTA { get; set; }

        public virtual Questao Questao { get; set; }
    }
}
