using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class StrongPointMap : EntityTypeConfiguration<StrongPoint>
    {
        public StrongPointMap()
        {
            ToTable("a9_ponto_forte_tb")
                .HasRequired<Coachee>(s => s.Coachee)
                .WithMany(s => s.StrongPoint)
                .HasForeignKey(x => x.IdCoachee);

            Property(x => x.Id)
                .HasColumnName("Id_Ponto_Forte")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoachee)
                .HasColumnName("a8_Id_Coachee_a9")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Nome_Ponto_Forte")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.ClassStrongPoint)
                .HasColumnName("Classe_Ponto_Forte")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Ponto_Forte")
                .IsOptional();
        }
    }
}
