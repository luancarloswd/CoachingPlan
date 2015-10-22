using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class MessageMap : EntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            ToTable("a22_Menssagem_tb")
                .HasRequired<User>(s => s.User)
                .WithMany(s => s.Message)
                .HasForeignKey(s => s.IdUser);

            Property(x => x.Id)
                .HasColumnName("Id_Menssagem")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdUser)
                .HasColumnName("a4_Id_Usuario_a22")
                .IsRequired();

            Property(x => x.Subject)
                .HasColumnName("Assunto_Menssagem")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.BodyMessage)
                .HasColumnName("Menssagem")
                .IsRequired();

            Property(x => x.Destination)
                .HasColumnName("Destino_Menssagem")
                .IsRequired();

            Property(x => x.Date)
                .HasColumnName("Data_Menssagem")
                .HasColumnType("DateTime")
                .IsRequired();

            Property(x => x.Status)
                .HasColumnName("Situacao_Menssagem")
                .IsRequired();
        }
    }
}
