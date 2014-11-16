namespace BullsAndCows.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;

    public class BullsAndCowsDbContext : IdentityDbContext<Player>
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCows", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<GuessNumber> GuessNumbers { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public IDbSet<UserInfo> UserInfos { get; set; }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }
    }
}