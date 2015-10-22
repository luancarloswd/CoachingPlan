using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            ToTable("a17_Servico_tb")
                .HasMany(t => t.CoachingProcess)
                .WithMany(t => t.Service)
                .Map(m =>
                {
                    m.ToTable("t10_servico_processo_tb");
                    m.MapLeftKey("a17_Id_Servico_t10");
                    m.MapRightKey("a11_Id_Processo_t10");
                }); ;

            Property(x => x.Id)
                .HasColumnName("Id_Servico")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasColumnName("Nome_Servico")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Value)
                .HasColumnName("Valor_Servico")
                .HasColumnType("Float")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Servico")
                .IsOptional();

        }
    }
}
