﻿using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data.Map;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace CoachingPlan.Infraestructure.Data
{
    public class AppDataContext : IdentityDbContext
    {
        public AppDataContext()
            :base("AppConnectionString")
        {
            Database.SetInitializer(new MySqlInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static AppDataContext()
        {
               DbConfiguration.SetConfiguration(new MySqlEFConfiguration()); 
        }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Coachee> Coachee { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Formacao> Formacao { get; set; }
        public DbSet<PontoForte> PontoForte { get; set; }
        public DbSet<Fragilidade> Fragilidade { get; set; }
        public DbSet<Dispositivo> Dispositivo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new TelefoneMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new PessoaMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Entity<IdentityUser>()
                .ToTable("a4_usuario_tb")
                .Property(x => x.Id).HasMaxLength(200);
            modelBuilder.Entity<IdentityUser>()
                .Property(x => x.UserName).HasMaxLength(200);
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("t1_logins_tb")
                .Property(x => x.UserId).HasMaxLength(200)
                    .HasColumnName("Id_Usuario");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("t2_claims_tb")
                .Property(x => x.UserId).HasMaxLength(200)
                    .HasColumnName("Id_Usuario");
            modelBuilder.Entity<IdentityRole>()
                .ToTable("t3_papel_tb")
                .Property(x => x.Id).HasMaxLength(200)
                    .HasColumnName("Id_Papel");
            modelBuilder.Entity<IdentityRole>()
                .Property(x => x.Name).HasMaxLength(200)
                    .HasColumnName("Nome_Papel");; 
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("t4_usuario_papel_tb")
                .Property(x => x.UserId).HasMaxLength(200)
                    .HasColumnName("Id_Usuario");
            modelBuilder.Entity<IdentityUserRole>()
               .Property(x => x.RoleId).HasMaxLength(200)
                   .HasColumnName("Id_Papel");
            modelBuilder.Configurations.Add(new CoachMap());
            modelBuilder.Configurations.Add(new CoacheeMap());
            modelBuilder.Configurations.Add(new FormacaoMap());
            modelBuilder.Configurations.Add(new EspecialidadeMap());
            modelBuilder.Configurations.Add(new PontoForteMap());
            modelBuilder.Configurations.Add(new FragilidadeMap());
            modelBuilder.Configurations.Add(new DispositivoMap());

        }
        public static AppDataContext Create()
        {
            return new AppDataContext();
        }
    }
}
