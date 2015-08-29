using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class WeaknessMap : EntityTypeConfiguration<Weakness>
    {
        public WeaknessMap()
        {
            ToTable("a10_fragilidade_tb")
                .HasRequired<Coachee>(s => s.Coachee)
                .WithMany(s => s.Weakness)
                .HasForeignKey(x => x.IdCoachee);

            Property(x => x.Id)
                .HasColumnName("Id_Fragilidade")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoachee)
                .HasColumnName("a8_Id_Coachee_a10");

            Property(x => x.Name)
                .HasColumnName("Nome_Fragilidade")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Fragilidade")
                .IsOptional();
        }
    }
}
