using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Domain.Models
{
    public class Logins 
    {
        public string LOGINPROVIDER { get; set; }
        public string PROVIDERKEY { get; set; }
        public string ID_USUARIO { get; set; }
        public string IDENTITYUSER_ID { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
