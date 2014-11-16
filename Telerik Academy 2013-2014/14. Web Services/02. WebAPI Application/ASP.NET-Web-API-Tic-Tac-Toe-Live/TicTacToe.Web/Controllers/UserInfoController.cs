namespace TicTacToe.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using TicTacToe.Data;
    using TicTacToe.Web.DataModels;
    using TicTacToe.Web.Infrastructure;

    [Authorize]
    public class UserInfoController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public UserInfoController(ITicTacToeData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult Get(string userId)
        {
            var userInfo = this.data.Users.All()
                .Where(u => u.Id == userId)
                .Select(u => new UserInfoDataModel
                    {
                        UserName = u.UserName,
                        Wins = u.Wins,
                        Looses = u.Losses
                    })
                .FirstOrDefault();

            if (userInfo == null)
            {
                return this.NotFound();
            }

            return this.Ok(userInfo);
        }
    }
}