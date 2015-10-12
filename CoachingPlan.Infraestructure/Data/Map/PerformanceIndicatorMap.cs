using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class PerformanceIndicatorMap : EntityTypeConfiguration<PerformanceIndicator>
    {
        public PerformanceIndicatorMap()
        {
            ToTable("t5_Incdr_Desempenho_tb")
                .HasRequired<CoachingProcess>(s => s.CoachingProcess)
                .WithMany(s => s.PerformanceIndicator)
                .HasForeignKey(s => s.IdCoachingProcess);

            Property(x => x.Id)
                .HasColumnName("Id_Incdr_Desempenho")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoachingProcess)
                .HasColumnName("a11_Id_Processo_t5")
                .IsRequired();

            Property(x => x.Indicator)
                .HasColumnName("Indicador")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
