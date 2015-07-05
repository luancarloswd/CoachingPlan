using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Sessao
    {
        public Sessao()
        {
            this.Tarefa = new HashSet<Tarefa>();
            this.Avaliacao = new HashSet<Avaliacao>();
        }

        public int ID_SESSAO { get; set; }
        public int ID_PROCESSO { get; set; }
        public string ID_USUARIO { get; set; }
        public string TEMA_SESSAO { get; set; }
        public System.DateTime DATA_SESSAO { get; set; }
        public System.TimeSpan INICIO_SESSAO { get; set; }
        public Nullable<System.TimeSpan> FIM_SESSAO { get; set; }
        public string CLASSIFICACAO_SESSAO { get; set; }
        public string OBSERVACAO_SESSAO { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Tarefa> Tarefa { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
        public virtual Processo_Coaching Processo_Coaching { get; set; }
    }
}
