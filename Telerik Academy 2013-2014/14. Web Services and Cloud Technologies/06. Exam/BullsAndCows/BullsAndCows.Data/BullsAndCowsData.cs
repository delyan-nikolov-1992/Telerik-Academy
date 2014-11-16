﻿namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class BullsAndCowsData : IBullsAndCowsData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public BullsAndCowsData(BullsAndCowsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<GuessNumber> GuessNumbers
        {
            get
            {
                return this.GetRepository<GuessNumber>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        // COULD NOT BE HERE
        public IRepository<UserInfo> UserInfos
        {
            get
            {
                return this.GetRepository<UserInfo>();
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
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}