using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class EvaluationMap : EntityTypeConfiguration<Evaluation>
    {
        public EvaluationMap()
        {
            ToTable("a13_Avaliacao_tb")
                .HasRequired<Session>(s => s.Session)
                .WithMany(s => s.Evaluation)
                .HasForeignKey(x => x.IdSession);

            HasRequired<User>(s => s.User)
                .WithMany(s => s.Evaluation)
                .HasForeignKey(x => x.IdUser);

            Property(x => x.Id)
                .HasColumnName("Id_Avaliacao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdSession)
                .HasColumnName("a12_Id_Sesso_a13")
                .IsRequired();

            Property(x => x.IdUser)
                .HasColumnName("a4_Id_Usuario_a13")
                .IsRequired();

            Property(x => x.Note)
                .HasColumnName("Nota_Avaliacao")
                .IsRequired();

            Property(x => x.Observation)
                .HasColumnName("Observacao_Processo")
                .IsOptional();

        }
    }
}
