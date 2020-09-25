namespace TransactionManagement.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startingcustomerclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserSince = c.DateTime(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
