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
    
    public partial class a23_especialidade_tb
    {
        public int ID_ESPECIALIDADE { get; set; }
        public string NOME_ESPECIALIDADE { get; set; }
        public string DESCRICAO_ESPECIALIDADE { get; set; }
        public int ID_COACH { get; set; }
    
        public virtual a5_coach_tb a5_coach_tb { get; set; }
    }
}