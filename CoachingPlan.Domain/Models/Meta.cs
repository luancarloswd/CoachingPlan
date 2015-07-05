using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Meta
    {
        public Meta()
        {
            this.Tarefa = new HashSet<Tarefa>();
        }

        public int ID_META { get; set; }
        public int ID_OBJETIVO { get; set; }
        public System.DateTime PRAZO_META { get; set; }
        public string DESC_META { get; set; }

        public virtual ICollection<Tarefa> Tarefa { get; set; }
        public virtual Objetivo Objetivo { get; set; }
        }
}
