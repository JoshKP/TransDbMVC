namespace TransactionManagement.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactioncrud : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        TargetedPromoId = c.Int(nullable: false),
                        DatePlaced = c.DateTimeOffset(nullable: false, precision: 7),
                        TypeOfPayment = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Transactions");
        }
    }
}
