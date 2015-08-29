using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class FormationMap : EntityTypeConfiguration<Formation>
    {
        public FormationMap()
        {
            ToTable("a6_formacao_tb")
                .HasRequired<Coach>(s => s.Coach)
                .WithMany(s => s.Formation)
                .HasForeignKey(x => x.IdCoach);

            Property(x => x.Id)
                .HasColumnName("Id_Formacao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoach)
                .HasColumnName("a5_Id_Coach_a6")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Nome_Formacao")
                .HasMaxLength(45)
                .IsRequired();

            Property(X => X.Description)
                .HasColumnName("Descricao_Formacao")
                .IsOptional();
        }
    }
}
