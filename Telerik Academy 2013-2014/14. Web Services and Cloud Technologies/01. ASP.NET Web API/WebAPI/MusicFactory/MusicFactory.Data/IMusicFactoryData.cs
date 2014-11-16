namespace MusicFactory.Data
{
    using MusicFactory.Data.Repositories;
    using MusicFactory.Models;

    public interface IMusicFactoryData
    {
        IRepository<Artist> Artists { get; }

        IRepository<Album> Albums { get; }

        IRepository<Song> Songs { get; }

        int SaveChanges();
    }
}