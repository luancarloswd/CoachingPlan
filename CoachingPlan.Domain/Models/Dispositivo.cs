using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Dispositivo
    {
        public Dispositivo()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string ClientKey { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
