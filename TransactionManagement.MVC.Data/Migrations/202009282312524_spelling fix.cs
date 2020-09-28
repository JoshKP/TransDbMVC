namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spellingfix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Company");
        }
    }
}
