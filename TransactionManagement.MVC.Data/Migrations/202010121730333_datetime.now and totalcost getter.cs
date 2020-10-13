namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenowandtotalcostgetter : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Transaction", "DatePlaced");
            DropColumn("dbo.Transaction", "TotalCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "TotalCost", c => c.Double(nullable: false));
            AddColumn("dbo.Transaction", "DatePlaced", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
