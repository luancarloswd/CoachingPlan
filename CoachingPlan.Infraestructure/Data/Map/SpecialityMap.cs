using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class SpecialityMap : EntityTypeConfiguration<Speciality>
    {
        public SpecialityMap()
        {
            ToTable("a7_especialidade_tb")
                .HasRequired<Coach>(s => s.Coach)
                .WithMany(s => s.Speciality)
                .HasForeignKey(x => x.IdCoach);

            Property(x => x.Id)
                .HasColumnName("Id_Especialidde")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoach)
                .HasColumnName("a5_Id_Coach_a7")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Nome_Especialidade")
                .HasMaxLength(45)
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Especialidade")
                .IsOptional();
        }
    }
}
