using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Claims
    {
        public int ID_CLAIMS { get; set; }
        public string ID_USUARIO { get; set; }
        public string CLAIMTYPE { get; set; }
        public string CLAIMVALUE { get; set; }
        public string IDENTITYUSER_ID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
