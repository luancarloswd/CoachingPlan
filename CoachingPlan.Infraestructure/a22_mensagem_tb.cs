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
    
    public partial class a22_mensagem_tb
    {
        public int ID_MENSAGEM { get; set; }
        public string ID_USUARIO { get; set; }
        public string ASSUNTO_MENSAGEM { get; set; }
        public string MENSAGEM { get; set; }
        public string DESTINO_MENSAGEM { get; set; }
        public System.DateTime DATA_MENSAGEM { get; set; }
    
        public virtual a4_usuario_tb a4_usuario_tb { get; set; }
    }
}