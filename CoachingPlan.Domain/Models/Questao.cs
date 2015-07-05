using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Questao
    {
        public Questao()
        {
            this.Resposta = new HashSet<Resposta>();
        }

        public int ID_QUESTAO { get; set; }
        public int ID_FERRAMENTA { get; set; }
        public string TIPO_RESPOSTA { get; set; }
        public string TIPO_QUESTAO { get; set; }
        public string FASE_QUESTAO { get; set; }
        public Nullable<int> PASSO_QUESTAO { get; set; }
        public string ENUNCIADO_QUESTAO { get; set; }
        public string INSTRUNCAO_QUESTAO { get; set; }

        public virtual Ferramenta_Avaliacao Ferramenta_Avaliacao { get; set; }
        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
