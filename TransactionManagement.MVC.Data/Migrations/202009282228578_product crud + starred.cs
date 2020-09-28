namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productcrudstarred : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "IsStarred", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "IsStarred");
        }
    }
}
