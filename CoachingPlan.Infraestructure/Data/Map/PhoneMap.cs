using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            ToTable("a2_telefone_tb")
                .HasRequired<Person>(s => s.Person)
                .WithMany(s => s.Phone)
                .HasForeignKey(s => s.IdPerson); ;


            Property(x => x.Id)
                .HasColumnName("Id_Telefone")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdPerson)
                .HasColumnName("a1_Id_Pessoa_a2")
                .IsRequired();

            Property(x => x.Number)
                .HasColumnName("Numero_Telefone")
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.DDD)
                .HasColumnName("DDD_Telefone")
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Telefone");
        }
    }
}
