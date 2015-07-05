using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Preenchimento_Ferramenta
    {
        public int ID_COACHEE { get; private set; }
        public int ID_FERRAMENTA { get; private set; }
        public System.DateTime Data_Avaliação { get; private set; }

        public virtual Ferramenta_Avaliacao Ferramenta_Avaliacao { get; set; }
        public virtual Coachee Coachee { get; set; }
    }
}
