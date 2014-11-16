namespace BullsAndCows.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    // separated model if in future the developer wants to extend the join request
    public class JoinResponseDataModel
    {
        [Required]
        public string Result { get; set; }
    }
}