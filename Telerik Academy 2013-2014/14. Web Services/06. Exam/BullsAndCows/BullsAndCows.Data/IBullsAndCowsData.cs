namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IBullsAndCowsData
    {
        IRepository<Game> Games { get; }

        IRepository<GuessNumber> GuessNumbers { get; }

        IRepository<Notification> Notifications { get; }

        // COULD NOT BE HERE
        IRepository<UserInfo> UserInfos{ get; }

        int SaveChanges();
    }
}