using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class FilledToolCoacheeMap : EntityTypeConfiguration<FilledToolCoachee>
    {
        public FilledToolCoacheeMap()
        {
            ToTable("t6_Prnchmnt_Frmt_Coachee_tb")
                .HasRequired<EvaluationTool>(s => s.EvaluationTool)
                .WithMany(s => s.FilledToolCoachee)
                .HasForeignKey(s => s.IdEvaluationTool);

            HasRequired<Coachee>(s => s.Coachee)
                .WithMany(s => s.FilledTool)
                .HasForeignKey(s => s.IdCoachee);

            HasRequired<CoachingProcess>(s => s.CoachingProcess)
                .WithMany(s => s.FilledToolCoachee)
                .HasForeignKey(s => s.IdCoachingProcess);

            Property(x => x.Id)
                .HasColumnName("Id_Resposta")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdEvaluationTool)
                .HasColumnName("a20_Id_Frmt_Avaliacao_t6")
                .IsRequired();

            Property(x => x.IdCoachee)
                .HasColumnName("a8_Id_Coachee_t6")
                .IsRequired();

            Property(x => x.IdCoachingProcess)
                .HasColumnName("a11_Id_Processo_t6")
                .IsRequired();

            Property(x => x.EvaluationDate)
                .HasColumnName("Data_Preenchimento")
                .HasColumnType("Date")
                .IsOptional();
        }
    }
}
