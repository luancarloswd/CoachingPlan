using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Ferramenta_Avaliacao
    {
        public Ferramenta_Avaliacao()
        {
            this.Questao = new HashSet<Questao>();
            this.Preechimento_Ferramenta = new HashSet<Preenchimento_Ferramenta>();
        }

        public int ID_FERRAMENTA { get; set; }
        public string NOME_FERRAMENTA { get; set; }
        public string TIPO_FERRAMENTA { get; set; }
        public int ID_COACH { get; set; }

        public virtual Coach Coach { get; set; }
        public virtual ICollection<Questao> Questao { get; set; }
        public virtual ICollection<Preenchimento_Ferramenta> Preechimento_Ferramenta { get; set; }
    }
}
