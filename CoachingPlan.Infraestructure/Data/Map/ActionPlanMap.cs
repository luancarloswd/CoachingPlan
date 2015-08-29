using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ActionPlanMap : EntityTypeConfiguration<ActionPlan>
    {
        public ActionPlanMap()
        {
            ToTable("a14_Plano_Acao_tb")
                .HasRequired<CoachingProcess>(s => s.CoachingProcess)
                .WithMany(s => s.ActionPlan)
                .HasForeignKey(x => x.IdCoachingProcess);

            Property(x => x.Id)
                .HasColumnName("Id_Plano_Acao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoachingProcess)
                .HasColumnName("a11_Id_Processo_a14")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Plano_Acao")
                .IsOptional();

        }
    }
}
