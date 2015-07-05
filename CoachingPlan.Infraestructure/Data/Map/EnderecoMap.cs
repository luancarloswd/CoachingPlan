using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("a3_Endereco_tb")
                .HasRequired<Pessoa>(s => s.Pessoa)
                .WithMany(s => s.Endereco);;

            Property(x => x.Id)
                .HasColumnName("Id_Endereco")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CEP)
                .HasColumnName("CEP_Endereco")
                .HasMaxLength(9)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.Estado)
                            .HasColumnName("Estado_Endereco")
                            .IsRequired();

            Property(x => x.Cidade)
                .HasColumnName("Cidade_Endereco")
                .HasMaxLength(35)
                .IsRequired();

            Property(x => x.Rua)
                .HasColumnName("Rua_Endereco")
                .HasMaxLength(70)
                .IsRequired();

            Property(x => x.Numero)
                .HasColumnName("Numero_Endereco")
                .IsRequired();

            Property(x => x.Tipo)
                .HasColumnName("Tipo_Endereco")
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("Descricao_Endereco")
                .HasMaxLength(40);
        }
    }
}
