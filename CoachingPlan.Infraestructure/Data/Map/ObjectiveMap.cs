using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ObjectiveMap : EntityTypeConfiguration<Objective>
    {
        public ObjectiveMap()
        {
            ToTable("a15_Objetivo_tb")
                .HasRequired<ActionPlan>(s => s.ActionPlan)
                .WithMany(s => s.Objective)
                .HasForeignKey(x => x.IdActionPlan);

            Property(x => x.Id)
                .HasColumnName("Id_Objetivo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdActionPlan)
                .HasColumnName("a14_Id_Plano_a15")
                .IsRequired();

            Property(x => x.Term)
                .HasColumnName("Prazo_Objetivo")
                .HasColumnType("Date")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Objetivo")
                .IsOptional();

        }
    }
}
