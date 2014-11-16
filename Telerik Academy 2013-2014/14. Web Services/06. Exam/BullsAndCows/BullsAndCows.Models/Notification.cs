namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        //// Unexpected Error
        // [Required]
        public string PlayerID { get; set; }

        public virtual Player Player { get; set; }

        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        public MessageState MessageState { get; set; }

        public MessageType MessageType { get; set; }
    }
}