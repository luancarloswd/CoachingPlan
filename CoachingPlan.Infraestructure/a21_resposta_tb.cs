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
    
    public partial class a21_resposta_tb
    {
        public int ID_RESPOSTA { get; set; }
        public int ID_QUESTAO { get; set; }
        public string RESPOSTA { get; set; }
    
        public virtual a20_questao_tb a20_questao_tb { get; set; }
    }
}
