using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class UsuarioMap : EntityTypeConfiguration<User>
    {
        public UsuarioMap()
        {
            ToTable("a4_usuario_tb")
                .HasRequired<People>(s => s.Pessoa)
                .WithMany(s => s.Usuario);

        }
    }
}
