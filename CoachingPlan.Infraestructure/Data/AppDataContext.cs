using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data.Map;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySql.Data.Entity;

namespace CoachingPlan.Infraestructure.Data
{
    public class AppDataContext : IdentityDbContext<User>
    {
        public AppDataContext()
            : base("AppConnectionString", throwIfV1Schema: true)
        {
            Database.SetInitializer(new MySqlInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        static AppDataContext()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Formation> Formation{ get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<Coachee> Coachee { get; set; }
        public DbSet<Weakness> Weakness { get; set; }
        public DbSet<StrongPoint> StrongPoint { get; set; }
        public DbSet<CoachingProcess> CoachingProcess { get; set; }
        public DbSet<Session> Session { get; set; }
        //public DbSet<Evaluation> Evaluation { get; set; }
        public DbSet<EvaluationCoach> EvaluationCoach { get; set; }
        public DbSet<EvaluationCoachee> EvaluationCoachee { get; set; }
        public DbSet <ActionPlan> ActionPlan { get; set; }
        public DbSet<Objective> Objective { get; set; }
        public DbSet<Mark> Mark { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<EvaluationTool> EvaluationTool { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<FilledTool> FilledTool { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<PerformanceIndicator> PerformanceIndicator { get; set; }
        public DbSet<Budget> Budget{ get; set; }
        public DbSet<Service> Service { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            modelBuilder.Entity<IdentityUser>()
                .ToTable("a4_usuario_tb")
                .Property(x => x.Id).HasMaxLength(200);
            modelBuilder.Entity<IdentityUser>()
                .Property(x => x.UserName).HasMaxLength(200);
            modelBuilder.Entity<User>()
                .ToTable("a4_usuario_tb")
                .Property(x => x.Id).HasMaxLength(200);
            modelBuilder.Entity<User>()
                .HasRequired<Person>(s => s.Person)
                .WithMany(s => s.User)
                .HasForeignKey(s => s.IdPerson);
            modelBuilder.Entity<User>()
                .Property(x => x.IdPerson)
                .HasColumnName("a1_Id_Pessoa_a4")
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.Id).HasMaxLength(200);
            modelBuilder.Entity<User>()
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
                    .HasColumnName("Nome_Papel"); ;
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("t4_usuario_papel_tb")
                .Property(x => x.UserId).HasMaxLength(200)
                    .HasColumnName("Id_Usuario");
            modelBuilder.Entity<IdentityUserRole>()
               .Property(x => x.RoleId).HasMaxLength(200)
                   .HasColumnName("Id_Papel");
            modelBuilder.Configurations.Add(new CoachMap());
            modelBuilder.Configurations.Add(new CoacheeMap());
            modelBuilder.Configurations.Add(new PerformanceIndicatorMap());
            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new FilledToolMap());
            modelBuilder.Configurations.Add(new ReplyMap());
            modelBuilder.Configurations.Add(new QuestionMap());
            modelBuilder.Configurations.Add(new EvaluationCoacheeMap());
            modelBuilder.Configurations.Add(new EvaluationCoachMap());
            modelBuilder.Configurations.Add(new ObjectiveMap());
            modelBuilder.Configurations.Add(new MarkMap());
            modelBuilder.Configurations.Add(new JobMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new EvaluationToolMap());
            modelBuilder.Configurations.Add(new FormationMap());
            modelBuilder.Configurations.Add(new WeaknessMap());
            modelBuilder.Configurations.Add(new SpecialityMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new ActionPlanMap());
            modelBuilder.Configurations.Add(new CoachingProcessMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new ServiceMap());
            modelBuilder.Configurations.Add(new StrongPointMap());
            modelBuilder.Configurations.Add(new BudgetMap());
        }
        public static AppDataContext Create()
        {
            return new AppDataContext();
        }
    }
}
