namespace FarmersMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TypeOfOrder = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Vegetables", t => t.Order, cascadeDelete: true)
                .Index(t => t.Order);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Order", "dbo.Vegetables");
            DropIndex("dbo.Customers", new[] { "Order" });
            DropTable("dbo.Customers");
        }
    }
}
