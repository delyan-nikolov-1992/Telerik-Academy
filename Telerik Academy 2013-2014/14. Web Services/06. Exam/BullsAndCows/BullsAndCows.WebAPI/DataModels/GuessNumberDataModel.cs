namespace BullsAndCows.WebAPI.DataModels
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GuessNumberDataModel
    {
        public static Expression<Func<GuessNumber, GuessNumberDataModel>> FromGuess
        {
            get
            {
                return g => new GuessNumberDataModel
                {
                    Id = g.Id,
                    UserId = g.PlayerID,
                    Username = g.Player.UserName,
                    GameId = g.GameID,
                    Number = g.Number,
                    DateMade = g.DateMade,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int GameId { get; set; }

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