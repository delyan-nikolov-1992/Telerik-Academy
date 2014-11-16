namespace MusicFactory.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<MusicFactoryDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "MusicFactory.Data.MusicFactoryDbContext";
        }

        protected override void Seed(MusicFactoryDbContext context)
        {
        }
    }
}