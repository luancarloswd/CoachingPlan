//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoachingPlan.Infraestructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class a19_ferramenta_tb
    {
        public a19_ferramenta_tb()
        {
            this.a20_questao_tb = new HashSet<a20_questao_tb>();
            this.t8_preenchimento_ferramenta_tb = new HashSet<t8_preenchimento_ferramenta_tb>();
        }
    
        public int ID_FERRAMENTA { get; set; }
        public string NOME_FERRAMENTA { get; set; }
        public string TIPO_FERRAMENTA { get; set; }
        public int ID_COACH { get; set; }
    
        public virtual a5_coach_tb a5_coach_tb { get; set; }
        public virtual ICollection<a20_questao_tb> a20_questao_tb { get; set; }
        public virtual ICollection<t8_preenchimento_ferramenta_tb> t8_preenchimento_ferramenta_tb { get; set; }
    }
}
