using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class CoacheeMap : EntityTypeConfiguration<Coachee>
    {
        public CoacheeMap()
        {
            ToTable("a8_coachee_tb")
                .HasMany(t => t.CoachingProcess)
                .WithMany(t => t.Coachee)
                .Map(m =>
                {
                    m.ToTable("t8_coachee_processo_tb");
                    m.MapLeftKey("a8_Id_Coachee_t8");
                    m.MapRightKey("a11_Id_Processo_t8");
                });



            HasRequired<User>(s => s.User)
                .WithMany(s => s.Coachee)
                .HasForeignKey(s => s.IdUser);

            Property(x => x.Id)
                .HasColumnName("Id_Coachee")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdUser)
                 .HasColumnName("a4_Id_Usuario_a8")
                 .IsRequired();

            Property(x => x.Profession)
                .HasColumnName("Profissao_Coachee")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
