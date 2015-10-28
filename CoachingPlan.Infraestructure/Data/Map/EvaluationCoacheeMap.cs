using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class EvaluationCoacheeMap : EntityTypeConfiguration<EvaluationCoachee>
    {
        public EvaluationCoacheeMap()
        {
            ToTable("t12_coachee_avaliacao_tb");

            HasRequired(t => t.Session)
                .WithMany(t => t.EvaluationCoachee)
                .HasForeignKey(t => t.IdSession);

            Property(x => x.Id)
                .HasColumnName("Id_Avaliacao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(t => t.Coachee)
               .WithMany(t => t.EvaluationCoachee)
               .HasForeignKey(t => t.IdCoachee);

            Property(x => x.IdCoachee)
                .HasColumnName("a5_fk_coachee_t12")
                .IsRequired();

            Property(x => x.IdSession)
                .HasColumnName("a12_fk_sessao_t12")
                .IsRequired();

            Property(x => x.Evaluation)
                .HasColumnName("Avaliacao")
                .IsOptional();

            Property(x => x.Observation)
                .HasColumnName("Observacao_Avaliacao")
                .IsOptional();
        }
    }
}
