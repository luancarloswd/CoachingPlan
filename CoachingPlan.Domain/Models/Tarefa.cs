using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Tarefa
    {
        public int ID_TAREFA { get; set; }
        public int ID_SESSAO { get; set; }
        public int ID_META { get; set; }
        public System.DateTime DATA_INICIO { get; set; }
        public System.DateTime DATA_REALIZACAO { get; set; }
        public System.DateTime DATA_VERIFICACAO { get; set; }
        public string DESCRICAO_TAREFA { get; set; }

        public virtual Sessao Sessao { get; set; }
        public virtual Meta Meta { get; set; }
    }
}
