﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class coaching_planEntities : DbContext
    {
        public coaching_planEntities()
            : base("name=coaching_planEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<a1_pessoa_tb> a1_pessoa_tb { get; set; }
        public virtual DbSet<a10_orcamento_tb> a10_orcamento_tb { get; set; }
        public virtual DbSet<a11_sessao_tb> a11_sessao_tb { get; set; }
        public virtual DbSet<a12_tarefa_tb> a12_tarefa_tb { get; set; }
        public virtual DbSet<a13_plano_acao_tb> a13_plano_acao_tb { get; set; }
        public virtual DbSet<a15_objetivo_tb> a15_objetivo_tb { get; set; }
        public virtual DbSet<a16_meta_tb> a16_meta_tb { get; set; }
        public virtual DbSet<a17_avaliacao_tb> a17_avaliacao_tb { get; set; }
        public virtual DbSet<a18_servico_tb> a18_servico_tb { get; set; }
        public virtual DbSet<a19_ferramenta_tb> a19_ferramenta_tb { get; set; }
        public virtual DbSet<a2_telefone_tb> a2_telefone_tb { get; set; }
        public virtual DbSet<a20_questao_tb> a20_questao_tb { get; set; }
        public virtual DbSet<a21_resposta_tb> a21_resposta_tb { get; set; }
        public virtual DbSet<a22_mensagem_tb> a22_mensagem_tb { get; set; }
        public virtual DbSet<a23_especialidade_tb> a23_especialidade_tb { get; set; }
        public virtual DbSet<a24_formacao_tb> a24_formacao_tb { get; set; }
        public virtual DbSet<a3_endereco_tb> a3_endereco_tb { get; set; }
        public virtual DbSet<a4_usuario_tb> a4_usuario_tb { get; set; }
        public virtual DbSet<a5_coach_tb> a5_coach_tb { get; set; }
        public virtual DbSet<a6_coachee_tb> a6_coachee_tb { get; set; }
        public virtual DbSet<a7_ponto_forte_tb> a7_ponto_forte_tb { get; set; }
        public virtual DbSet<a8_fragilidade_tb> a8_fragilidade_tb { get; set; }
        public virtual DbSet<a9_processo_coaching_tb> a9_processo_coaching_tb { get; set; }
        public virtual DbSet<t1_logins_tb> t1_logins_tb { get; set; }
        public virtual DbSet<t2_claims_tb> t2_claims_tb { get; set; }
        public virtual DbSet<t3_papel_tb> t3_papel_tb { get; set; }
        public virtual DbSet<t4_usuario_papel_tb> t4_usuario_papel_tb { get; set; }
        public virtual DbSet<t5_indicador_desempenho_tb> t5_indicador_desempenho_tb { get; set; }
        public virtual DbSet<t8_preenchimento_ferramenta_tb> t8_preenchimento_ferramenta_tb { get; set; }
    }
}