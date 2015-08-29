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
                .HasRequired<User>(s => s.User)
                .WithMany(s => s.Coach);

            Property(x => x.Id)
                .HasColumnName("Id_Coach")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
