using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class BudgetMap : EntityTypeConfiguration<Budget>
    {
        public BudgetMap()
        {
            ToTable("a19_Orcamento_tb")
                .HasRequired<CoachingProcess>(s => s.CoachingProcess)
                .WithMany(s => s.Budget)
                .HasForeignKey(s => s.IdCoachingProcess);

            Property(x => x.Id)
                .HasColumnName("Id_Orcamento")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdCoachingProcess)
                .HasColumnName("a11_Id_Processo_a19")
                .IsRequired();

            Property(x => x.Proposal)
                .HasColumnName("Propoesta_Orcamento")
                .IsRequired();

            Property(x => x.Price)
                .HasColumnName("Preco_Orcamento")
                .HasColumnType("Float")
                .IsRequired();

            Property(x => x.ProposalDate)
                .HasColumnName("Date_Orcamento")
                .IsRequired();

            Property(x => x.SessionPrice)
                .HasColumnName("Preco_Sessao_Orcamento")
                .HasColumnType("Float")
                .IsRequired();

        }
    }
}
