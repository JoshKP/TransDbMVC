namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buildcreatefortransandsupp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "SupplierId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "SupplierId");
        }
    }
}
