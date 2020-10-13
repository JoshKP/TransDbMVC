namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweaks1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transaction", "TotalCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "TotalCost", c => c.Double(nullable: false));
        }
    }
}
