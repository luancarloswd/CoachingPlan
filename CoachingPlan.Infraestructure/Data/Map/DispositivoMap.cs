using CoachingPlan.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoachingPlan.Infraestructure.Data.Map
{
    public class DispositivoMap : EntityTypeConfiguration<Dispositivo>
    {
        public DispositivoMap()
        {
            ToTable("t5_dispositivo_tb")
                .HasRequired<Usuario>(s => s.Usuario)
                .WithMany(s => s.Dispositivo);
            Property(x => x.Id)
                .HasColumnName("Id_Dispositivo")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
