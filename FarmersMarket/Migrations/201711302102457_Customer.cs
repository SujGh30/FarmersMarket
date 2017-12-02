namespace FarmersMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Customers", name: "Order", newName: "VegetableID");
            RenameIndex(table: "dbo.Customers", name: "IX_Order", newName: "IX_VegetableID");
            AddColumn("dbo.Customers", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Vegetables", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vegetables", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Customers", "Quantity");
            RenameIndex(table: "dbo.Customers", name: "IX_VegetableID", newName: "IX_Order");
            RenameColumn(table: "dbo.Customers", name: "VegetableID", newName: "Order");
        }
    }
}
