namespace MusicFactory.Data
{
    using System.Data.Entity;

    using MusicFactory.Data.Migrations;
    using MusicFactory.Models;

    public class MusicFactoryDbContext : DbContext
    {
        public MusicFactoryDbContext()
            : base("MusicFactory")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicFactoryDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public static MusicFactoryDbContext Create()
        {
            return new MusicFactoryDbContext();
        }
    }
}