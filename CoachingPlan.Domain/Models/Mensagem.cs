using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Mensagem
    {
        public int ID_MENSAGEM { get; set; }
        public string ID_USUARIO { get; set; }
        public string ASSUNTO_MENSAGEM { get; set; }
        public string MENSAGEM { get; set; }
        public string DESTINO_MENSAGEM { get; set; }
        public System.DateTime DATA_MENSAGEM { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
