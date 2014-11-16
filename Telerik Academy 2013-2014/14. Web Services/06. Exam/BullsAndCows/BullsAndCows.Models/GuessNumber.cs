using System;
using System.ComponentModel.DataAnnotations;
namespace BullsAndCows.Models
{
    public class GuessNumber
    {
        public int Id { get; set; }

        //// Unexpected Error
        // [Required]
        public string PlayerID { get; set; }

        public virtual Player Player { get; set; }

        public int GameID { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }

        public DateTime DateMade { get; set; }

        [Range(0, 4)]
        public int CowsCount { get; set; }

        [Range(0, 4)]
        public int BullsCount { get; set; }
    }
}