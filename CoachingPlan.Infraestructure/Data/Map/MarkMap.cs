using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class MarkMap : EntityTypeConfiguration<Mark>
    {
        public MarkMap()
        {
            ToTable("a15_Meta_tb")
                .HasRequired<Objective>(s => s.Objective)
                .WithMany(s => s.Mark)
                .HasForeignKey(x => x.IdObjective);

            Property(x => x.Id)
                .HasColumnName("Id_Meta")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdObjective)
                .HasColumnName("a14_Id_Objective_a16")
                .IsRequired();

            Property(x => x.Term)
                .HasColumnName("Prazo_Meta")
                .HasColumnType("Date")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Meta")
                .IsOptional();

        }
    }
}
