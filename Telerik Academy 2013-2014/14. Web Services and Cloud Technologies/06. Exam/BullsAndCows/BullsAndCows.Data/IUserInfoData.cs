namespace BullsAndCows.Data
{
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public interface IUserInfoData
    {
        IRepository<UserInfo> UserInfos { get; }

        int SaveChanges();
    }
}