using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            ToTable("a1_pessoa_tb");

            Property(x => x.Id)
                .HasColumnName("Id_Pessoa")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasColumnName("Nome_Pessoa")
                .HasMaxLength(65)
                .IsRequired();

            Property(x => x.CPF)
                .HasColumnName("CPF_Pessoa")
                .HasMaxLength(11)
                .IsFixedLength()
                .IsRequired()
                .HasColumnAnnotation(
                    "Index", new IndexAnnotation(new IndexAttribute("IX_CPF") { IsUnique = true })); ;

            Property(X => X.Genre)
                .HasColumnName("Genero_Pessoa")
                .IsRequired();


            Property(x => x.BirthDate)
               .HasColumnName("Data_Nascimento_Pessoa")
               .HasColumnType("Date")
               .IsRequired();

            Property(x => x.Photograph)
                .HasColumnName("Foto_Pessoa");
        }
    }
}
