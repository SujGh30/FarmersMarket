namespace FarmersMarket
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FarmerMarketModel : DbContext
    {
        // Your context has been configured to use a 'FarmerMarketModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FarmersMarket.FarmerMarketModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FarmerMarketModel' 
        // connection string in the application configuration file.
        public FarmerMarketModel()
            : base("name=FarmerMarketModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Vegetables> Vegetables { get; set; }
    }

    
}