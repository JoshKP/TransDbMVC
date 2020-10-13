namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tweaks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "DatePlaced", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "DatePlaced");
        }
    }
}
