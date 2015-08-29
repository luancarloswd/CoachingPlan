using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            ToTable("a21_Questao_tb")
                .HasRequired<EvaluationTool>(s=> s.EvaluationTool)
                .WithMany(s=> s.Question)
                .HasForeignKey(s=> s.IdEvaluationTool);

            Property(x => x.Id)
                .HasColumnName("Id_Questao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdEvaluationTool)
                .HasColumnName("a20_Id_Frmt_Avlc_a21");

            Property(x => x.TypeReply)
                .HasColumnName("Tipo_Resposta_Questao")
                .IsRequired();

            Property(x => x.TypeQuestion)
                .HasColumnName("Tipo_Questao")
                .IsRequired();

            Property(x => x.PhaseQuestion)
                .HasColumnName("Fase_Questao")
                .IsRequired();

            Property(x => x.StepQuestion)
                .HasColumnName("Passo_Questao")
                .IsRequired();

            Property(x => x.Enunciation)
                .HasColumnName("Enunciado_Questao")
                .IsOptional();

            Property(x => x.Education)
                .HasColumnName("Instrucao_Questao")
                .IsOptional();


        }
    }
}
