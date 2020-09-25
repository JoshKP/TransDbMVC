namespace TransactionManagement.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customercrud : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "UserSince", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "UserSince", c => c.DateTime(nullable: false));
        }
    }
}
