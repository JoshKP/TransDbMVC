namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class untweak : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "TotalCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "TotalCost");
        }
    }
}
