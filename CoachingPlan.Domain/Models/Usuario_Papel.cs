using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Usuario_Papel
    {
        public string ID_USUARIO { get; set; }
        public string ID_PAPEL { get; set; }
        public string IDENTITYUSER_ID { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Papel Papel { get; set; }
    }
}
