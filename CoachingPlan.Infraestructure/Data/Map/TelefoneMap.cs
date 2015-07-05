using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class TelefoneMap : EntityTypeConfiguration<Telefone>
    {
        public TelefoneMap()
        {
            ToTable("a2_telefone_tb")
                .HasRequired<Pessoa>(s => s.Pessoa)
                .WithMany(s => s.Telefone);


            Property(x => x.Id)
                .HasColumnName("Id_Telefone")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Numero)
                .HasColumnName("Numero_Telefone")
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.DDD)
                .HasColumnName("DDD_Telefone")
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("Descricao_Telefone");
        }
    }
}
