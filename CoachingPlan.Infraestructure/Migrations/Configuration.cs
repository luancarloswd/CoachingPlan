namespace CoachingPlan.Infraestructure.Migrations
{
    using CoachingPlan.Infraestructure.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoachingPlan.Infraestructure.Data.AppDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
            SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }

        protected override void Seed(CoachingPlan.Infraestructure.Data.AppDataContext context)
        {
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Administrator"});
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Coach" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "Coachee" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Name = "SessionManager" });
        }
    }
}
