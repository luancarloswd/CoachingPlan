using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ReplyMap : EntityTypeConfiguration<Reply>
    {
        public ReplyMap()
        {
            ToTable("a21_Resposta_tb")
                .HasRequired<Question>(s => s.Question)
                .WithMany(s => s.Reply)
                .HasForeignKey(s => s.IdQuestion);

            Property(x => x.Id)
                .HasColumnName("Id_Resposta")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdQuestion)
                .HasColumnName("a20_Id_Questao_a22");

            Property(x => x.Status)
                .HasColumnName("Situacao_Resposta");

            Property(x => x.BodyReply)
                .HasColumnName("Resposta")
                .IsRequired();

            Property(x => x.Group)
            .HasColumnName("Grupo_Resposta")
            .IsOptional()
            .HasMaxLength(20);
        }
    }
}
