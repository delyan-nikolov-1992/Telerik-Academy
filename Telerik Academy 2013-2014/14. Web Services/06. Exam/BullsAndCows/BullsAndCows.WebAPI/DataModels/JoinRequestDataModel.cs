namespace BullsAndCows.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    // separated model if in future the developer wants to extend the join request
    public class JoinRequestDataModel
    {
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }
    }
}