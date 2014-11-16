namespace BullsAndCows.WebAPI.Controllers
{
    using BullsAndCows.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    using BullsAndCows.Models;
    using BullsAndCows.WebAPI.DataModels;
    using System.Text;
    using BullsAndCows.Logic;

    public class NotificationsController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        public NotificationsController(IBullsAndCowsData data)
            : base(data)
        {
        }


        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            return this.Get(0);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult Get(int page)
        {
            var notifications = this.GetNotificationsSorted()
                .Skip(page * DefaultPageSize)
                .Take(DefaultPageSize);



            // no games that are in state available for joining
            if (notifications.Count() == 0)
            {
                return this.NotFound();
            }

            foreach (var item in notifications)
            {
                item.MessageState = MessageState.Read;
            }

            this.Data.SaveChanges();

            return this.Ok(notifications);
        }

        private IEnumerable<Notification> GetNotificationsSorted()
        {
            return this.Data.Notifications.All()
                .Where(g => g.MessageState == MessageState.Unread)
                .OrderBy(g => g.DateCreated);
        }
    }
}