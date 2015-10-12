namespace CoachingPlan.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.a14_Plano_Acao_tb",
                c => new
                    {
                        Id_Plano_Acao = c.Guid(nullable: false, identity: true),
                        a11_Id_Processo_a14 = c.Guid(nullable: false),
                        Descricao_Plano_Acao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Plano_Acao)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_a14, cascadeDelete: true)
                .Index(t => t.a11_Id_Processo_a14);
            
            CreateTable(
                "dbo.a11_Processo_Coaching_tb",
                c => new
                    {
                        Id_Processo_Coaching = c.Guid(nullable: false, identity: true),
                        Nome_Processo = c.String(nullable: false, maxLength: 70, storeType: "nvarchar"),
                        Data_Inicio_Processo = c.DateTime(nullable: false, storeType: "date"),
                        Data_Fim_Processo = c.DateTime(storeType: "date"),
                        Modalidade_Processo_Coaching = c.Int(nullable: false),
                        Observacao_Processo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Processo_Coaching);
            
            CreateTable(
                "dbo.a19_Orcamento_tb",
                c => new
                    {
                        Id_Orcamento = c.Guid(nullable: false, identity: true),
                        a11_Id_Processo_a19 = c.Guid(nullable: false),
                        Propoesta_Orcamento = c.String(nullable: false, unicode: false),
                        Preco_Orcamento = c.Single(nullable: false),
                        Date_Orcamento = c.DateTime(nullable: false, precision: 0),
                        Preco_Sessao_Orcamento = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Orcamento)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_a19, cascadeDelete: true)
                .Index(t => t.a11_Id_Processo_a19);
            
            CreateTable(
                "dbo.a5_coach_tb",
                c => new
                    {
                        Id_Coach = c.Guid(nullable: false, identity: true),
                        a4_Id_Usuario_a5 = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Coach)
                .ForeignKey("dbo.a4_usuario_tb", t => t.a4_Id_Usuario_a5, cascadeDelete: true)
                .Index(t => t.a4_Id_Usuario_a5);
            
            CreateTable(
                "dbo.a20_Frmt_Avaliacao_tb",
                c => new
                    {
                        Id_Frmt_Avaliacao = c.Guid(nullable: false, identity: true),
                        Nome_Frmt_Avaliacao = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Tipo_Frmt_Avaliacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Frmt_Avaliacao);
            
            CreateTable(
                "dbo.t6_Preenchimento_Frmt_tb",
                c => new
                    {
                        Id_Resposta = c.Guid(nullable: false, identity: true),
                        a20_Id_Frmt_Avaliacao_t6 = c.Guid(nullable: false),
                        a8_Id_Frmt_Avaliacao_t6 = c.Guid(nullable: false),
                        Data_Preenchimento = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id_Resposta)
                .ForeignKey("dbo.a8_coachee_tb", t => t.a8_Id_Frmt_Avaliacao_t6, cascadeDelete: true)
                .ForeignKey("dbo.a20_Frmt_Avaliacao_tb", t => t.a20_Id_Frmt_Avaliacao_t6, cascadeDelete: true)
                .Index(t => t.a20_Id_Frmt_Avaliacao_t6)
                .Index(t => t.a8_Id_Frmt_Avaliacao_t6);
            
            CreateTable(
                "dbo.a8_coachee_tb",
                c => new
                    {
                        Id_Coachee = c.Guid(nullable: false, identity: true),
                        a4_Id_Usuario_a8 = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Profissao_Coachee = c.String(nullable: false, maxLength: 25, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Coachee)
                .ForeignKey("dbo.a4_usuario_tb", t => t.a4_Id_Usuario_a8, cascadeDelete: true)
                .Index(t => t.a4_Id_Usuario_a8);
            
            CreateTable(
                "dbo.a12_Sessao_tb",
                c => new
                    {
                        Id_Sessao = c.Guid(nullable: false, identity: true),
                        a11_Id_Processo_a12 = c.Guid(nullable: false),
                        a4_Id_Usuario_a12 = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Tema_Sessao = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Data_Sessao = c.DateTime(nullable: false, storeType: "date"),
                        Inicio_Sessao = c.Time(nullable: false, precision: 0),
                        Fim_Sessao = c.Time(precision: 0),
                        Classificacao_Sessao = c.Int(nullable: false),
                        Observacao_Sessao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Sessao)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_a12, cascadeDelete: true)
                .ForeignKey("dbo.a4_usuario_tb", t => t.a4_Id_Usuario_a12, cascadeDelete: true)
                .Index(t => t.a11_Id_Processo_a12)
                .Index(t => t.a4_Id_Usuario_a12);
            
            CreateTable(
                "dbo.a13_Avaliacao_tb",
                c => new
                    {
                        Id_Avaliacao = c.Guid(nullable: false, identity: true),
                        Nota_Avaliacao = c.Single(nullable: false),
                        Observacao_Processo = c.String(unicode: false),
                        a12_Id_Sesso_a13 = c.Guid(nullable: false),
                        a4_Id_Usuario_a13 = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Avaliacao)
                .ForeignKey("dbo.a12_Sessao_tb", t => t.a12_Id_Sesso_a13, cascadeDelete: true)
                .ForeignKey("dbo.a4_usuario_tb", t => t.a4_Id_Usuario_a13, cascadeDelete: true)
                .Index(t => t.a12_Id_Sesso_a13)
                .Index(t => t.a4_Id_Usuario_a13);
            
            CreateTable(
                "dbo.a4_usuario_tb",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        a1_Id_Pessoa_a4 = c.Guid(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.a1_pessoa_tb", t => t.a1_Id_Pessoa_a4, cascadeDelete: true)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.a1_Id_Pessoa_a4);
            
            CreateTable(
                "dbo.t2_claims_tb",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Usuario = c.String(maxLength: 200, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                        IdentityUser_Id = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.a4_usuario_tb", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.t1_logins_tb",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Id_Usuario = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        IdentityUser_Id = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.Id_Usuario })
                .ForeignKey("dbo.a4_usuario_tb", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.a23_Menssagem_tb",
                c => new
                    {
                        Id_Menssagem = c.Guid(nullable: false, identity: true),
                        a4_Id_Usuario_a23 = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Assunto_Menssagem = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Menssagem = c.String(nullable: false, unicode: false),
                        Destino_Menssagem = c.Guid(nullable: false),
                        Data_Menssagem = c.DateTime(nullable: false, precision: 0),
                        Situacao_Menssagem = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Menssagem)
                .ForeignKey("dbo.a4_usuario_tb", t => t.a4_Id_Usuario_a23, cascadeDelete: true)
                .Index(t => t.a4_Id_Usuario_a23);
            
            CreateTable(
                "dbo.a1_pessoa_tb",
                c => new
                    {
                        Id_Pessoa = c.Guid(nullable: false, identity: true),
                        Nome_Pessoa = c.String(nullable: false, maxLength: 65, storeType: "nvarchar"),
                        CPF_Pessoa = c.String(nullable: false, maxLength: 11, fixedLength: true, storeType: "nchar"),
                        Data_Nascimento_Pessoa = c.DateTime(nullable: false, storeType: "date"),
                        Genero_Pessoa = c.Int(nullable: false),
                        Status_Pessoa = c.Boolean(nullable: false),
                        Foto_Pessoa = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Pessoa)
                .Index(t => t.CPF_Pessoa, unique: true, name: "IX_CPF");
            
            CreateTable(
                "dbo.a3_Endereco_tb",
                c => new
                    {
                        Id_Endereco = c.Guid(nullable: false, identity: true),
                        CEP_Endereco = c.String(nullable: false, maxLength: 9, fixedLength: true, storeType: "nchar"),
                        Estado_Endereco = c.Int(nullable: false),
                        Cidade_Endereco = c.String(nullable: false, maxLength: 35, storeType: "nvarchar"),
                        Rua_Endereco = c.String(nullable: false, maxLength: 70, storeType: "nvarchar"),
                        Numero_Endereco = c.Int(nullable: false),
                        Tipo_Endereco = c.Int(nullable: false),
                        Descricao_Endereco = c.String(maxLength: 40, storeType: "nvarchar"),
                        a1_Id_Pessoa_a3 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Endereco)
                .ForeignKey("dbo.a1_pessoa_tb", t => t.a1_Id_Pessoa_a3, cascadeDelete: true)
                .Index(t => t.a1_Id_Pessoa_a3);
            
            CreateTable(
                "dbo.a2_telefone_tb",
                c => new
                    {
                        Id_Telefone = c.Guid(nullable: false, identity: true),
                        DDD_Telefone = c.String(nullable: false, maxLength: 2, fixedLength: true, storeType: "nchar"),
                        Numero_Telefone = c.String(nullable: false, maxLength: 8, fixedLength: true, storeType: "nchar"),
                        Descricao_Telefone = c.String(unicode: false),
                        a1_Id_Pessoa_a2 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Telefone)
                .ForeignKey("dbo.a1_pessoa_tb", t => t.a1_Id_Pessoa_a2, cascadeDelete: true)
                .Index(t => t.a1_Id_Pessoa_a2);
            
            CreateTable(
                "dbo.t4_usuario_papel_tb",
                c => new
                    {
                        Id_Usuario = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Id_Papel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        IdentityUser_Id = c.String(maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.Id_Usuario, t.Id_Papel })
                .ForeignKey("dbo.t3_papel_tb", t => t.Id_Papel, cascadeDelete: true)
                .ForeignKey("dbo.a4_usuario_tb", t => t.IdentityUser_Id)
                .Index(t => t.Id_Papel)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.a17_Tarefa_tb",
                c => new
                    {
                        Id_Tarefa = c.Guid(nullable: false, identity: true),
                        a12_Id_Sessao_a17 = c.Guid(nullable: false),
                        a16_Id_Meta_a17 = c.Guid(nullable: false),
                        Data_Inicio_Tarefa = c.DateTime(nullable: false, storeType: "date"),
                        Data_Realizacao_Tarefa = c.DateTime(storeType: "date"),
                        Data_Verificacao_Tarefa = c.DateTime(nullable: false, storeType: "date"),
                        Descricao_Meta = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Tarefa)
                .ForeignKey("dbo.a16_Meta_tb", t => t.a16_Id_Meta_a17, cascadeDelete: true)
                .ForeignKey("dbo.a12_Sessao_tb", t => t.a12_Id_Sessao_a17, cascadeDelete: true)
                .Index(t => t.a12_Id_Sessao_a17)
                .Index(t => t.a16_Id_Meta_a17);
            
            CreateTable(
                "dbo.a16_Meta_tb",
                c => new
                    {
                        Id_Meta = c.Guid(nullable: false, identity: true),
                        a15_Id_Objective_a16 = c.Guid(nullable: false),
                        Prazo_Meta = c.DateTime(nullable: false, storeType: "date"),
                        Descricao_Meta = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Meta)
                .ForeignKey("dbo.a15_Objetivo_tb", t => t.a15_Id_Objective_a16, cascadeDelete: true)
                .Index(t => t.a15_Id_Objective_a16);
            
            CreateTable(
                "dbo.a15_Objetivo_tb",
                c => new
                    {
                        Id_Objetivo = c.Guid(nullable: false, identity: true),
                        Descricao_Objetivo = c.String(unicode: false),
                        Prazo_Objetivo = c.DateTime(nullable: false, storeType: "date"),
                        a14_Id_Plano_a15 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Objetivo)
                .ForeignKey("dbo.a14_Plano_Acao_tb", t => t.a14_Id_Plano_a15, cascadeDelete: true)
                .Index(t => t.a14_Id_Plano_a15);
            
            CreateTable(
                "dbo.a9_ponto_forte_tb",
                c => new
                    {
                        Id_Ponto_Forte = c.Guid(nullable: false, identity: true),
                        a8_Id_Coachee_a9 = c.Guid(nullable: false),
                        Nome_Ponto_Forte = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Classe_Ponto_Forte = c.Int(nullable: false),
                        Descricao_Ponto_Forte = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Ponto_Forte)
                .ForeignKey("dbo.a8_coachee_tb", t => t.a8_Id_Coachee_a9, cascadeDelete: true)
                .Index(t => t.a8_Id_Coachee_a9);
            
            CreateTable(
                "dbo.a10_fragilidade_tb",
                c => new
                    {
                        Id_Fragilidade = c.Guid(nullable: false, identity: true),
                        a8_Id_Coachee_a10 = c.Guid(nullable: false),
                        Nome_Fragilidade = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        Descricao_Fragilidade = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Fragilidade)
                .ForeignKey("dbo.a8_coachee_tb", t => t.a8_Id_Coachee_a10, cascadeDelete: true)
                .Index(t => t.a8_Id_Coachee_a10);
            
            CreateTable(
                "dbo.a21_Questao_tb",
                c => new
                    {
                        Id_Questao = c.Guid(nullable: false, identity: true),
                        a20_Id_Frmt_Avlc_a21 = c.Guid(nullable: false),
                        Tipo_Resposta_Questao = c.Int(nullable: false),
                        Tipo_Questao = c.Int(nullable: false),
                        Fase_Questao = c.Int(nullable: false),
                        Passo_Questao = c.Int(nullable: false),
                        Enunciado_Questao = c.String(unicode: false),
                        Instrucao_Questao = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Questao)
                .ForeignKey("dbo.a20_Frmt_Avaliacao_tb", t => t.a20_Id_Frmt_Avlc_a21, cascadeDelete: true)
                .Index(t => t.a20_Id_Frmt_Avlc_a21);
            
            CreateTable(
                "dbo.a22_Resposta_tb",
                c => new
                    {
                        Id_Resposta = c.Guid(nullable: false, identity: true),
                        a21_Id_Questao_a22 = c.Guid(nullable: false),
                        Resposta = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id_Resposta)
                .ForeignKey("dbo.a21_Questao_tb", t => t.a21_Id_Questao_a22, cascadeDelete: true)
                .Index(t => t.a21_Id_Questao_a22);
            
            CreateTable(
                "dbo.a6_formacao_tb",
                c => new
                    {
                        Id_Formacao = c.Guid(nullable: false, identity: true),
                        Nome_Formacao = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Descricao_Formacao = c.String(unicode: false),
                        a5_Id_Coach_a6 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Formacao)
                .ForeignKey("dbo.a5_coach_tb", t => t.a5_Id_Coach_a6, cascadeDelete: true)
                .Index(t => t.a5_Id_Coach_a6);
            
            CreateTable(
                "dbo.a7_especialidade_tb",
                c => new
                    {
                        Id_Especialidde = c.Guid(nullable: false, identity: true),
                        Nome_Especialidade = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        Descricao_Especialidade = c.String(unicode: false),
                        a5_Id_Coach_a7 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Especialidde)
                .ForeignKey("dbo.a5_coach_tb", t => t.a5_Id_Coach_a7, cascadeDelete: true)
                .Index(t => t.a5_Id_Coach_a7);
            
            CreateTable(
                "dbo.t5_Incdr_Desempenho_tb",
                c => new
                    {
                        Id_Incdr_Desempenho = c.Guid(nullable: false, identity: true),
                        a11_Id_Processo_t5 = c.Guid(nullable: false),
                        Indicador = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Incdr_Desempenho)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_t5, cascadeDelete: true)
                .Index(t => t.a11_Id_Processo_t5);
            
            CreateTable(
                "dbo.a18_Servico_tb",
                c => new
                    {
                        Id_Servico = c.Guid(nullable: false, identity: true),
                        Nome_Servico = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        Valor_Servico = c.Single(nullable: false),
                        Descricao_Servico = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id_Servico);
            
            CreateTable(
                "dbo.t3_papel_tb",
                c => new
                    {
                        Id_Papel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Nome_Papel = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id_Papel)
                .Index(t => t.Nome_Papel, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.t7_coach_processo_tb",
                c => new
                    {
                        a5_Id_Coach_t7 = c.Guid(nullable: false),
                        a11_Id_Processo_t7 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a5_Id_Coach_t7, t.a11_Id_Processo_t7 })
                .ForeignKey("dbo.a5_coach_tb", t => t.a5_Id_Coach_t7, cascadeDelete: true)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_t7, cascadeDelete: true)
                .Index(t => t.a5_Id_Coach_t7)
                .Index(t => t.a11_Id_Processo_t7);
            
            CreateTable(
                "dbo.t9_coach_ferramenta_tb",
                c => new
                    {
                        a5_Id_Coach_t9 = c.Guid(nullable: false),
                        a20_Id_Ferramenta_t9 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a5_Id_Coach_t9, t.a20_Id_Ferramenta_t9 })
                .ForeignKey("dbo.a20_Frmt_Avaliacao_tb", t => t.a5_Id_Coach_t9, cascadeDelete: true)
                .ForeignKey("dbo.a5_coach_tb", t => t.a20_Id_Ferramenta_t9, cascadeDelete: true)
                .Index(t => t.a5_Id_Coach_t9)
                .Index(t => t.a20_Id_Ferramenta_t9);
            
            CreateTable(
                "dbo.t8_coachee_processo_tb",
                c => new
                    {
                        a8_Id_Coachee_t8 = c.Guid(nullable: false),
                        a11_Id_Processo_t8 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a8_Id_Coachee_t8, t.a11_Id_Processo_t8 })
                .ForeignKey("dbo.a8_coachee_tb", t => t.a8_Id_Coachee_t8, cascadeDelete: true)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_t8, cascadeDelete: true)
                .Index(t => t.a8_Id_Coachee_t8)
                .Index(t => t.a11_Id_Processo_t8);
            
            CreateTable(
                "dbo.t12_coachee_session_tb",
                c => new
                    {
                        a8_Id_Coachee_t12 = c.Guid(nullable: false),
                        a12_Id_Sessao_t12 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a8_Id_Coachee_t12, t.a12_Id_Sessao_t12 })
                .ForeignKey("dbo.a8_coachee_tb", t => t.a8_Id_Coachee_t12, cascadeDelete: true)
                .ForeignKey("dbo.a12_Sessao_tb", t => t.a12_Id_Sessao_t12, cascadeDelete: true)
                .Index(t => t.a8_Id_Coachee_t12)
                .Index(t => t.a12_Id_Sessao_t12);
            
            CreateTable(
                "dbo.t11_coach_session_tb",
                c => new
                    {
                        a5_Id_Coach_t11 = c.Guid(nullable: false),
                        a12_Id_Sessao_t11 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a5_Id_Coach_t11, t.a12_Id_Sessao_t11 })
                .ForeignKey("dbo.a5_coach_tb", t => t.a5_Id_Coach_t11, cascadeDelete: true)
                .ForeignKey("dbo.a12_Sessao_tb", t => t.a12_Id_Sessao_t11, cascadeDelete: true)
                .Index(t => t.a5_Id_Coach_t11)
                .Index(t => t.a12_Id_Sessao_t11);
            
            CreateTable(
                "dbo.t10_servico_processo_tb",
                c => new
                    {
                        a18_Id_Servico_t10 = c.Guid(nullable: false),
                        a11_Id_Processo_t10 = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.a18_Id_Servico_t10, t.a11_Id_Processo_t10 })
                .ForeignKey("dbo.a18_Servico_tb", t => t.a18_Id_Servico_t10, cascadeDelete: true)
                .ForeignKey("dbo.a11_Processo_Coaching_tb", t => t.a11_Id_Processo_t10, cascadeDelete: true)
                .Index(t => t.a18_Id_Servico_t10)
                .Index(t => t.a11_Id_Processo_t10);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t4_usuario_papel_tb", "IdentityUser_Id", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.t1_logins_tb", "IdentityUser_Id", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.t2_claims_tb", "IdentityUser_Id", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.t4_usuario_papel_tb", "Id_Papel", "dbo.t3_papel_tb");
            DropForeignKey("dbo.a14_Plano_Acao_tb", "a11_Id_Processo_a14", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.t10_servico_processo_tb", "a11_Id_Processo_t10", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.t10_servico_processo_tb", "a18_Id_Servico_t10", "dbo.a18_Servico_tb");
            DropForeignKey("dbo.t5_Incdr_Desempenho_tb", "a11_Id_Processo_t5", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.a5_coach_tb", "a4_Id_Usuario_a5", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.a7_especialidade_tb", "a5_Id_Coach_a7", "dbo.a5_coach_tb");
            DropForeignKey("dbo.t11_coach_session_tb", "a12_Id_Sessao_t11", "dbo.a12_Sessao_tb");
            DropForeignKey("dbo.t11_coach_session_tb", "a5_Id_Coach_t11", "dbo.a5_coach_tb");
            DropForeignKey("dbo.a6_formacao_tb", "a5_Id_Coach_a6", "dbo.a5_coach_tb");
            DropForeignKey("dbo.a22_Resposta_tb", "a21_Id_Questao_a22", "dbo.a21_Questao_tb");
            DropForeignKey("dbo.a21_Questao_tb", "a20_Id_Frmt_Avlc_a21", "dbo.a20_Frmt_Avaliacao_tb");
            DropForeignKey("dbo.t6_Preenchimento_Frmt_tb", "a20_Id_Frmt_Avaliacao_t6", "dbo.a20_Frmt_Avaliacao_tb");
            DropForeignKey("dbo.t6_Preenchimento_Frmt_tb", "a8_Id_Frmt_Avaliacao_t6", "dbo.a8_coachee_tb");
            DropForeignKey("dbo.a10_fragilidade_tb", "a8_Id_Coachee_a10", "dbo.a8_coachee_tb");
            DropForeignKey("dbo.a8_coachee_tb", "a4_Id_Usuario_a8", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.a9_ponto_forte_tb", "a8_Id_Coachee_a9", "dbo.a8_coachee_tb");
            DropForeignKey("dbo.t12_coachee_session_tb", "a12_Id_Sessao_t12", "dbo.a12_Sessao_tb");
            DropForeignKey("dbo.t12_coachee_session_tb", "a8_Id_Coachee_t12", "dbo.a8_coachee_tb");
            DropForeignKey("dbo.a12_Sessao_tb", "a4_Id_Usuario_a12", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.a17_Tarefa_tb", "a12_Id_Sessao_a17", "dbo.a12_Sessao_tb");
            DropForeignKey("dbo.a17_Tarefa_tb", "a16_Id_Meta_a17", "dbo.a16_Meta_tb");
            DropForeignKey("dbo.a16_Meta_tb", "a15_Id_Objective_a16", "dbo.a15_Objetivo_tb");
            DropForeignKey("dbo.a15_Objetivo_tb", "a14_Id_Plano_a15", "dbo.a14_Plano_Acao_tb");
            DropForeignKey("dbo.a13_Avaliacao_tb", "a4_Id_Usuario_a13", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.a4_usuario_tb", "a1_Id_Pessoa_a4", "dbo.a1_pessoa_tb");
            DropForeignKey("dbo.a2_telefone_tb", "a1_Id_Pessoa_a2", "dbo.a1_pessoa_tb");
            DropForeignKey("dbo.a3_Endereco_tb", "a1_Id_Pessoa_a3", "dbo.a1_pessoa_tb");
            DropForeignKey("dbo.a23_Menssagem_tb", "a4_Id_Usuario_a23", "dbo.a4_usuario_tb");
            DropForeignKey("dbo.a13_Avaliacao_tb", "a12_Id_Sesso_a13", "dbo.a12_Sessao_tb");
            DropForeignKey("dbo.a12_Sessao_tb", "a11_Id_Processo_a12", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.t8_coachee_processo_tb", "a11_Id_Processo_t8", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.t8_coachee_processo_tb", "a8_Id_Coachee_t8", "dbo.a8_coachee_tb");
            DropForeignKey("dbo.t9_coach_ferramenta_tb", "a20_Id_Ferramenta_t9", "dbo.a5_coach_tb");
            DropForeignKey("dbo.t9_coach_ferramenta_tb", "a5_Id_Coach_t9", "dbo.a20_Frmt_Avaliacao_tb");
            DropForeignKey("dbo.t7_coach_processo_tb", "a11_Id_Processo_t7", "dbo.a11_Processo_Coaching_tb");
            DropForeignKey("dbo.t7_coach_processo_tb", "a5_Id_Coach_t7", "dbo.a5_coach_tb");
            DropForeignKey("dbo.a19_Orcamento_tb", "a11_Id_Processo_a19", "dbo.a11_Processo_Coaching_tb");
            DropIndex("dbo.t10_servico_processo_tb", new[] { "a11_Id_Processo_t10" });
            DropIndex("dbo.t10_servico_processo_tb", new[] { "a18_Id_Servico_t10" });
            DropIndex("dbo.t11_coach_session_tb", new[] { "a12_Id_Sessao_t11" });
            DropIndex("dbo.t11_coach_session_tb", new[] { "a5_Id_Coach_t11" });
            DropIndex("dbo.t12_coachee_session_tb", new[] { "a12_Id_Sessao_t12" });
            DropIndex("dbo.t12_coachee_session_tb", new[] { "a8_Id_Coachee_t12" });
            DropIndex("dbo.t8_coachee_processo_tb", new[] { "a11_Id_Processo_t8" });
            DropIndex("dbo.t8_coachee_processo_tb", new[] { "a8_Id_Coachee_t8" });
            DropIndex("dbo.t9_coach_ferramenta_tb", new[] { "a20_Id_Ferramenta_t9" });
            DropIndex("dbo.t9_coach_ferramenta_tb", new[] { "a5_Id_Coach_t9" });
            DropIndex("dbo.t7_coach_processo_tb", new[] { "a11_Id_Processo_t7" });
            DropIndex("dbo.t7_coach_processo_tb", new[] { "a5_Id_Coach_t7" });
            DropIndex("dbo.t3_papel_tb", "RoleNameIndex");
            DropIndex("dbo.t5_Incdr_Desempenho_tb", new[] { "a11_Id_Processo_t5" });
            DropIndex("dbo.a7_especialidade_tb", new[] { "a5_Id_Coach_a7" });
            DropIndex("dbo.a6_formacao_tb", new[] { "a5_Id_Coach_a6" });
            DropIndex("dbo.a22_Resposta_tb", new[] { "a21_Id_Questao_a22" });
            DropIndex("dbo.a21_Questao_tb", new[] { "a20_Id_Frmt_Avlc_a21" });
            DropIndex("dbo.a10_fragilidade_tb", new[] { "a8_Id_Coachee_a10" });
            DropIndex("dbo.a9_ponto_forte_tb", new[] { "a8_Id_Coachee_a9" });
            DropIndex("dbo.a15_Objetivo_tb", new[] { "a14_Id_Plano_a15" });
            DropIndex("dbo.a16_Meta_tb", new[] { "a15_Id_Objective_a16" });
            DropIndex("dbo.a17_Tarefa_tb", new[] { "a16_Id_Meta_a17" });
            DropIndex("dbo.a17_Tarefa_tb", new[] { "a12_Id_Sessao_a17" });
            DropIndex("dbo.t4_usuario_papel_tb", new[] { "IdentityUser_Id" });
            DropIndex("dbo.t4_usuario_papel_tb", new[] { "Id_Papel" });
            DropIndex("dbo.a2_telefone_tb", new[] { "a1_Id_Pessoa_a2" });
            DropIndex("dbo.a3_Endereco_tb", new[] { "a1_Id_Pessoa_a3" });
            DropIndex("dbo.a1_pessoa_tb", "IX_CPF");
            DropIndex("dbo.a23_Menssagem_tb", new[] { "a4_Id_Usuario_a23" });
            DropIndex("dbo.t1_logins_tb", new[] { "IdentityUser_Id" });
            DropIndex("dbo.t2_claims_tb", new[] { "IdentityUser_Id" });
            DropIndex("dbo.a4_usuario_tb", new[] { "a1_Id_Pessoa_a4" });
            DropIndex("dbo.a4_usuario_tb", "UserNameIndex");
            DropIndex("dbo.a13_Avaliacao_tb", new[] { "a4_Id_Usuario_a13" });
            DropIndex("dbo.a13_Avaliacao_tb", new[] { "a12_Id_Sesso_a13" });
            DropIndex("dbo.a12_Sessao_tb", new[] { "a4_Id_Usuario_a12" });
            DropIndex("dbo.a12_Sessao_tb", new[] { "a11_Id_Processo_a12" });
            DropIndex("dbo.a8_coachee_tb", new[] { "a4_Id_Usuario_a8" });
            DropIndex("dbo.t6_Preenchimento_Frmt_tb", new[] { "a8_Id_Frmt_Avaliacao_t6" });
            DropIndex("dbo.t6_Preenchimento_Frmt_tb", new[] { "a20_Id_Frmt_Avaliacao_t6" });
            DropIndex("dbo.a5_coach_tb", new[] { "a4_Id_Usuario_a5" });
            DropIndex("dbo.a19_Orcamento_tb", new[] { "a11_Id_Processo_a19" });
            DropIndex("dbo.a14_Plano_Acao_tb", new[] { "a11_Id_Processo_a14" });
            DropTable("dbo.t10_servico_processo_tb");
            DropTable("dbo.t11_coach_session_tb");
            DropTable("dbo.t12_coachee_session_tb");
            DropTable("dbo.t8_coachee_processo_tb");
            DropTable("dbo.t9_coach_ferramenta_tb");
            DropTable("dbo.t7_coach_processo_tb");
            DropTable("dbo.t3_papel_tb");
            DropTable("dbo.a18_Servico_tb");
            DropTable("dbo.t5_Incdr_Desempenho_tb");
            DropTable("dbo.a7_especialidade_tb");
            DropTable("dbo.a6_formacao_tb");
            DropTable("dbo.a22_Resposta_tb");
            DropTable("dbo.a21_Questao_tb");
            DropTable("dbo.a10_fragilidade_tb");
            DropTable("dbo.a9_ponto_forte_tb");
            DropTable("dbo.a15_Objetivo_tb");
            DropTable("dbo.a16_Meta_tb");
            DropTable("dbo.a17_Tarefa_tb");
            DropTable("dbo.t4_usuario_papel_tb");
            DropTable("dbo.a2_telefone_tb");
            DropTable("dbo.a3_Endereco_tb");
            DropTable("dbo.a1_pessoa_tb");
            DropTable("dbo.a23_Menssagem_tb");
            DropTable("dbo.t1_logins_tb");
            DropTable("dbo.t2_claims_tb");
            DropTable("dbo.a4_usuario_tb");
            DropTable("dbo.a13_Avaliacao_tb");
            DropTable("dbo.a12_Sessao_tb");
            DropTable("dbo.a8_coachee_tb");
            DropTable("dbo.t6_Preenchimento_Frmt_tb");
            DropTable("dbo.a20_Frmt_Avaliacao_tb");
            DropTable("dbo.a5_coach_tb");
            DropTable("dbo.a19_Orcamento_tb");
            DropTable("dbo.a11_Processo_Coaching_tb");
            DropTable("dbo.a14_Plano_Acao_tb");
        }
    }
}
