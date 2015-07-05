using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Processo_Coaching
    {
        public Processo_Coaching()
        {
            this.Orcamento = new HashSet<Orcamento>();
            this.Sessao = new HashSet<Sessao>();
            this.Plano_Acao = new HashSet<Plano_Acao>();
            this.Indicador_Desempenho = new HashSet<Indicador_Desempenho>();
            this.Coachee = new HashSet<Coachee>();
            this.Servico = new HashSet<Servico>();
        }

        public int ID_PROCESSO { get; set; }
        public int ID_COACH { get; set; }
        public System.DateTime DATA_INICIO_PROCESSO { get; set; }
        public Nullable<System.DateTime> DATA_FIM_PROCESSO { get; set; }
        public string MODALIDADE_PROCESSO { get; set; }
        public string OBSERVACAO_PROCESSO { get; set; }

        public virtual ICollection<Orcamento> Orcamento { get; set; }
        public virtual ICollection<Sessao> Sessao { get; set; }
        public virtual ICollection<Plano_Acao> Plano_Acao { get; set; }
        public virtual Coach Coach { get; set; }
        public virtual ICollection<Indicador_Desempenho> Indicador_Desempenho { get; set; }
        public virtual ICollection<Coachee> Coachee { get; set; }
        public virtual ICollection<Servico> Servico { get; set; }
    }
}
