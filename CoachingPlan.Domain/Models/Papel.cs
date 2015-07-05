using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Papel
    {
        public Papel()
        {
            //this.Usuario_Papel = new HashSet<Usuario_Papel>();
        }

        public string ID_PAPEL { get; set; }
        public string NOME_PAPEL { get; set; }

        //public virtual ICollection<Usuario_Papel> Usuario_Papel { get; set; }
    }
}
