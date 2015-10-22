using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class JobMap : EntityTypeConfiguration<Job>
    {
        public JobMap()
        {
            ToTable("a16_Tarefa_tb")
                .HasRequired<Mark>(s => s.Mark)
                .WithMany(s => s.Job)
                .HasForeignKey(x => x.IdMark);

            HasOptional<Session>(s => s.Session)
                .WithMany(s => s.Job)
                .HasForeignKey(x => x.IdSession);

            Property(x => x.Id)
                .HasColumnName("Id_Tarefa")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.IdMark)
                .HasColumnName("a15_Id_Meta_a17")
                .IsRequired();

            Property(x => x.IdSession)
                .HasColumnName("a12_Id_Sessao_a17")
                .IsOptional();

            Property(x => x.StartDate)
                .HasColumnName("Data_Inicio_Tarefa")
                .HasColumnType("Date")
                .IsRequired();

            Property(x => x.RealizationDate)
                .HasColumnName("Data_Realizacao_Tarefa")
                .HasColumnType("Date")
                .IsOptional();

            Property(x => x.VerificationDate)
                .HasColumnName("Data_Verificacao_Tarefa")
                .HasColumnType("Date")
                .IsRequired();

            Property(x => x.Description)
                .HasColumnName("Descricao_Meta")
                .IsOptional();

        }
    }
}
