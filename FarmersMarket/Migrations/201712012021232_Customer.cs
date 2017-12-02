namespace FarmersMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "AddressToDeliver", c => c.String());
            AddColumn("dbo.Customers", "EmailAddress", c => c.String());
            DropColumn("dbo.Customers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            DropColumn("dbo.Customers", "EmailAddress");
            DropColumn("dbo.Customers", "AddressToDeliver");
        }
    }
}
