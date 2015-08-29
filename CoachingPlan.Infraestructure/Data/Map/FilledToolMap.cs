using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class FilledToolMap : EntityTypeConfiguration<FilledTool>
    {
        public FilledToolMap()
        {
            ToTable("t6_Preenchimento_Frmt_tb")
                .HasRequired<EvaluationTool>(s => s.EvaluationTool)
                .WithMany(s => s.FilledTool)
                .HasForeignKey(s => s.IdEvaluationTool);

            HasRequired<Coachee>(s => s.Coachee)
                .WithMany(s => s.FilledTool)
                .HasForeignKey(s => s.IdCoachee);

            Property(x => x.Id)
                .HasColumnName("Id_Resposta")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdEvaluationTool)
                .HasColumnName("a20_Id_Frmt_Avaliacao_t6")
                .IsRequired();

            Property(x => x.IdCoachee)
                .HasColumnName("a8_Id_Frmt_Avaliacao_t6")
                .IsRequired();

            Property(x => x.EvaluationDate)
                .HasColumnName("Data_Preenchimento")
                .HasColumnType("Date")
                .IsRequired();
        }
    }
}
