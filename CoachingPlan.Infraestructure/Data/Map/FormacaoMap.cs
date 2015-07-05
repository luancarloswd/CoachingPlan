using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class FormacaoMap : EntityTypeConfiguration<Formacao>
    {
        public FormacaoMap()
        {
            ToTable("a8_formacao_tb")
                .HasRequired<Coach>(s => s.Coach)
                .WithMany(s => s.Formacao);

            Property(x => x.Id)
                .HasColumnName("Id_Formacao")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("Nome_Formacao")
                .HasMaxLength(45)
                .IsRequired();

            Property(X => X.Descricao)
                .HasColumnName("Descricao_Formacao")
                .IsOptional();
        }
    }
}
