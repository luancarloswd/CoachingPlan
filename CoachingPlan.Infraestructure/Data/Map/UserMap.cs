using CoachingPlan.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("a4_usuario_tb")
                .HasRequired<Person>(s => s.Person)
                .WithMany(s => s.User)
                .HasForeignKey(s => s.IdPerson);

            Property(x => x.IdPerson)
                .HasColumnName("a1_Id_Pessoa_a4")
                .IsRequired();
        }
    }
}
