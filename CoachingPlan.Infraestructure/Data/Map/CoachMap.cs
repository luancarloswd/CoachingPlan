using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class CoachMap : EntityTypeConfiguration<Coach>
    {
        public CoachMap()
        {
            ToTable("a5_coach_tb")
                .HasMany(t => t.CoachingProcess)
                .WithMany(t => t.Coach)
                .Map(m =>
                {
                    m.ToTable("t7_coach_processo_tb");
                    m.MapLeftKey("a5_Id_Coach_t7");
                    m.MapRightKey("a11_Id_Processo_t7");
                });


              HasMany(t => t.Session)
                .WithMany(t => t.Coach)
                .Map(m =>
                {
                    m.ToTable("t11_coach_session_tb");
                    m.MapLeftKey("a5_Id_Coach_t11");
                    m.MapRightKey("a12_Id_Sessao_t11");
                });

            HasRequired<User>(s => s.User)
                .WithMany(s => s.Coach)
                .HasForeignKey(s => s.IdUser);

            Property(x => x.Id)
                .HasColumnName("Id_Coach")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdUser)
                .HasColumnName("a4_Id_Usuario_a5")
                .IsRequired();
        }
    }
}
