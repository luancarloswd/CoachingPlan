using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Luan", "10559753659", DateTime.Parse("22-02-1994"), CoachingPlan.Domain.Enums.EGenre.M, true);
            person.AddAddress("38610000", CoachingPlan.Domain.Enums.EStates.MG, "Unaí", "Av. Vereador Joaõ Narciso", 160, CoachingPlan.Domain.Enums.EAddressType.Residential);
            person.Validate();
        }
    }
}
