using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachingPlan.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Endereco endereco = new Endereco("38610-000", Domain.Enums.EEstado.Estados.AC, "Unaí", "aav", 21, Domain.Enums.ETipoEndereco.TipoEndereco.Comercial, "dafs");
            endereco.Validate();
            Console.WriteLine(endereco.Estado); 
        }
    }
}
