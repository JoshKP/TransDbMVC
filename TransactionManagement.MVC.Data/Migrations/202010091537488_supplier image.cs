namespace TransactionManagement.MVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplier", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Supplier", "Image");
        }
    }
}
