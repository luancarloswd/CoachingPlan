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
    
    public partial class t3_papel_tb
    {
        public t3_papel_tb()
        {
            this.t4_usuario_papel_tb = new HashSet<t4_usuario_papel_tb>();
        }
    
        public string ID_PAPEL { get; set; }
        public string NOME_PAPEL { get; set; }
    
        public virtual ICollection<t4_usuario_papel_tb> t4_usuario_papel_tb { get; set; }
    }
}