using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class EspecialidadeMap : EntityTypeConfiguration<Speciality>
    {
        public EspecialidadeMap()
        {
            ToTable("a7_especialidade_tb")
                .HasRequired<Coach>(s => s.Coach)
                .WithMany(s => s.Especialidade);

            Property(x => x.Id)
                .HasColumnName("Id_Especialidde")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

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
