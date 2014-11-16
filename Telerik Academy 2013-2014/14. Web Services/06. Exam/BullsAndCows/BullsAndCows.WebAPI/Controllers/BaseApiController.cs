namespace BullsAndCows.WebAPI.Controllers
{
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.RandomGenerator;

    public class BaseApiController : ApiController
    {
        private IRandomDataGenerator random;

        public BaseApiController(IBullsAndCowsData data)
        {
            this.Data = data;
            this.random = RandomDataGenerator.Instance;
        }

        protected IBullsAndCowsData Data { get; set; }

        protected IRandomDataGenerator Random
        {
            get
            {
                return this.random;
            }
        }
    }
}