using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class FilledToolCoachMap : EntityTypeConfiguration<FilledToolCoach>
    {
        public FilledToolCoachMap()
        {
            ToTable("t13_Prnchnt_Frmt_Coach_tb")
                .HasRequired<EvaluationTool>(s => s.EvaluationTool)
                .WithMany(s => s.FilledToolCoach)
                .HasForeignKey(s => s.IdEvaluationTool);

            HasRequired<Coach>(s => s.Coach)
                .WithMany(s => s.FilledTollCoach)
                .HasForeignKey(s => s.IdCoach);

            HasRequired<CoachingProcess>(s => s.CoachingProcess)
                .WithMany(s => s.FilledToolCoach)
                .HasForeignKey(s => s.IdCoachingProcess);

            Property(x => x.Id)
                .HasColumnName("Id_Resposta")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdEvaluationTool)
                .HasColumnName("a20_Id_Frmt_Avaliacao_t13")
                .IsRequired();

            Property(x => x.IdCoach)
                .HasColumnName("a5_Id_Coach_t13")
                .IsRequired();

            Property(x => x.IdCoachingProcess)
                .HasColumnName("a11_Id_Processo_t13")
                .IsRequired();

            Property(x => x.EvaluationDate)
                .HasColumnName("Data_Preenchimento")
                .HasColumnType("Date")
                .IsRequired();
        }
    }
}
