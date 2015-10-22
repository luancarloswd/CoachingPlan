using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ActionPlanMap : EntityTypeConfiguration<ActionPlan>
    {
        public ActionPlanMap()
        {
            ToTable("a13_Plano_Acao_tb");


            Property(x => x.Id)
                .HasColumnName("Id_Plano_Acao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Description)
                .HasColumnName("Descricao_Plano_Acao")
                .IsOptional();

        }
    }
}
