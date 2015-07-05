using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Ponto_Forte
    {
        public int ID_PONTO_FORTE { get; set; }
        public int ID_COACHEE { get; set; }
        public string PONTO_FORTE { get; set; }
        public string CLASSE_PONTO_FORTE { get; set; }
        public string DESCRICAO_PONTO_FORTE { get; set; }

        public virtual Coachee Coachee { get; set; }
    }
}
