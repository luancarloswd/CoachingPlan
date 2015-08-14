using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class PessoaMap : EntityTypeConfiguration<People>
    {
        public PessoaMap()
        {
            ToTable("a1_pessoa_tb");

            Property(x => x.Id)
                .HasColumnName("Id_Pessoa")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasColumnName("Nome_Pessoa")
                .HasMaxLength(65)
                .IsRequired();

            Property(X => X.Genero)
                .HasColumnName("Genero_Pessoa")
                .IsRequired();

            Property(x => x.CPF)
                .HasColumnName("CPF_Pessoa")
                .HasMaxLength(11)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.BirthDate)
               .HasColumnName("Data_Nascimento_Pessoa")
               .HasColumnType("Date")
               .IsRequired();

            Property(x => x.Status)
                .HasColumnName("Status_Pessoa")
                .IsRequired();

            Property(x => x.Foto)
                .HasColumnName("Foto_Pessoa");
        }
    }
}
