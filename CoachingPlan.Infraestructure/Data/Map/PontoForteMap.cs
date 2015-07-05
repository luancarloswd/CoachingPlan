using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class PontoForteMap : EntityTypeConfiguration<PontoForte>
    {
        public PontoForteMap()
        {
            ToTable("a9_ponto_forte_tb")
                .HasRequired<Coachee>(s => s.Coachee)
                .WithMany(s => s.PontoForte);

            Property(x => x.Id)
                .HasColumnName("Id_Ponto_Forte")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome)
                .HasColumnName("Nome_Ponto_Foret")
                .HasMaxLength(30)
                .IsRequired();

            Property(x => x.Descricao)
                .HasColumnName("Descricao_Ponto_Forte")
                .IsOptional();
        }
    }
}
