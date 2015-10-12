namespace CoachingPlan.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.a19_Orcamento_tb", "Status_Orcamento", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.a19_Orcamento_tb", "Status_Orcamento");
        }
    }
}
