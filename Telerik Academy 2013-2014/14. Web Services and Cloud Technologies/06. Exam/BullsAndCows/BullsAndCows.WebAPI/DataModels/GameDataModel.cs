namespace BullsAndCows.WebAPI.DataModels
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameDataModel
    {
        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer == null ? "No blue player yet" : g.BluePlayer.UserName,
                    Red = g.RedPlayer.UserName,
                    GameState = g.GameState,
                    DateCreated = g.DateCreated
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Blue { get; set; }

        [Required]
        public string Red { get; set; }

        [Required]
        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}