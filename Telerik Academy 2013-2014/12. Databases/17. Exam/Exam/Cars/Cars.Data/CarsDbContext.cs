namespace Cars.Data
{
    using System.Data.Entity;

    using Cars.Data.Migrations;
    using Cars.Models;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
            : base("Cars")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarsDbContext, Configuration>());
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }

        public IDbSet<City> Cities { get; set; }
    }
}