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
    
    public partial class a16_meta_tb
    {
        public a16_meta_tb()
        {
            this.a12_tarefa_tb = new HashSet<a12_tarefa_tb>();
        }
    
        public int ID_META { get; set; }
        public int ID_OBJETIVO { get; set; }
        public System.DateTime PRAZO_META { get; set; }
        public string DESC_META { get; set; }
    
        public virtual ICollection<a12_tarefa_tb> a12_tarefa_tb { get; set; }
        public virtual a15_objetivo_tb a15_objetivo_tb { get; set; }
    }
}
