using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("a4_usuario_tb")
                .HasRequired<Pessoa>(s => s.Pessoa)
                .WithMany(s => s.Usuario);

            Property(x => x.Id)
                .HasColumnName("Id_Usuario")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();

            Property(x => x.EmailConfirmed)
                .HasColumnName("Email_Confirmado")
                .IsRequired();

            Property(x => x.PhoneNumber)
                .HasColumnName("Numero_Telefone");

            Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("Numero_Telefone_Confirmado");


        }
    }
}
