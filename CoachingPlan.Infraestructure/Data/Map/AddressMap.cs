using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable("a3_Endereco_tb")
                .HasRequired<Person>(s => s.Person)
                .WithMany(s => s.Address)
                .HasForeignKey(s => s.IdPerson);

            Property(x => x.Id)
                .HasColumnName("Id_Endereco")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdPerson)
                .HasColumnName("a1_Id_Pessoa_a3")
                .IsRequired();

            Property(x => x.CEP)
                .HasColumnName("CEP_Endereco")
                .HasMaxLength(9)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.State)
                .HasColumnName("Estado_Endereco")
                .IsRequired();

            Property(x => x.City)
                .HasColumnName("Cidade_Endereco")
                .HasMaxLength(35)
                .IsRequired();

            Property(x => x.Street)
                .HasColumnName("Rua_Endereco")
                .HasMaxLength(70)
                .IsRequired();

            Property(x => x.Number)
                .HasColumnName("Numero_Endereco")
                .IsRequired();

            Property(x => x.Type)
                .HasColumnName("Tipo_Endereco")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Endereco")
                .HasMaxLength(40);
        }
    }
}
