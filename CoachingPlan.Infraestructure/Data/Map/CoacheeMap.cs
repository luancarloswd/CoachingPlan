using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class CoacheeMap : EntityTypeConfiguration<Coachee>
    {
        public CoacheeMap()
        {
            ToTable("a6_coachee_tb")
                .HasRequired<User>(s => s.User)
                .WithMany(s => s.Coachee);
            Property(x => x.Id)
                .HasColumnName("Id_Coachee")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Profession)
                .HasColumnName("Profissao_Coachee")
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
