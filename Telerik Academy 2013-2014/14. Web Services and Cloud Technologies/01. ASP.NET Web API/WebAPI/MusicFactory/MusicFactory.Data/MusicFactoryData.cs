namespace MusicFactory.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using MusicFactory.Data.Repositories;
    using MusicFactory.Models;

    public class MusicFactoryData : IMusicFactoryData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public MusicFactoryData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}