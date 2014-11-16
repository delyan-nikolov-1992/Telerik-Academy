namespace BullsAndCows.WebAPI.DataModels
{
    using BullsAndCows.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class GameDetailsDataModels
    {
        private IEnumerable<GuessNumberDataModel> yourGuesses;
        private IEnumerable<GuessNumberDataModel> opponentGuesses;

        public GameDetailsDataModels(Game game)
        {
            this.yourGuesses = new HashSet<GuessNumberDataModel>();
            this.opponentGuesses = new HashSet<GuessNumberDataModel>();

            this.Id = game.Id;
            this.Name = game.Name;
            this.DateCreated = game.DateCreated;
            this.Red = game.RedPlayer.UserName;
            this.Blue = game.BluePlayer.UserName;
            this.YourNumber = game.GameState == GameState.RedInTurn ? game.RedPlayerNumber : game.BluePlayerNumber;
            this.YourGuesses = game.GameState == GameState.RedInTurn ?
                game.GuessNumbers.AsQueryable()
                .Where(guess => guess.PlayerID == game.RedPlayerID)
                .Select(GuessNumberDataModel.FromGuess) :
                game.GuessNumbers.AsQueryable()
                .Where(guess => guess.PlayerID == game.BluePlayerID)
                .Select(GuessNumberDataModel.FromGuess);
            this.OpponentGuesses = game.GameState == GameState.BlueInTurn ?
                game.GuessNumbers.AsQueryable()
                .Where(guess => guess.PlayerID == game.RedPlayerID)
                .Select(GuessNumberDataModel.FromGuess) :
                game.GuessNumbers.AsQueryable()
                .Where(guess => guess.PlayerID == game.BluePlayerID)
                .Select(GuessNumberDataModel.FromGuess);
            this.YourColor = game.GameState == GameState.RedInTurn ? "red" : "blue";
            this.GameState = game.GameState;
        }

        //public static Expression<Func<Game, GameDetailsDataModels>> FromGame
        //{
        //    get
        //    {
        //        return g => new GameDetailsDataModels
        //        {
        //            Id = g.Id,
        //            Name = g.Name,
        //            DateCreated = g.DateCreated,
        //            Red = g.RedPlayer.UserName,
        //            Blue = g.BluePlayer.UserName,
        //            YourNumber = g.GameState == GameState.RedInTurn ? g.RedPlayerNumber : g.BluePlayerNumber,
        //            YourGuesses = g.GameState == GameState.RedInTurn ?
        //                g.GuessNumbers.AsQueryable()
        //                .Where(guess => guess.PlayerID == g.RedPlayerID)
        //                .Select(GuessNumberDataModel.FromGuess) :
        //                g.GuessNumbers.AsQueryable()
        //                .Where(guess => guess.PlayerID == g.BluePlayerID)
        //                .Select(GuessNumberDataModel.FromGuess),
        //            OpponentGuesses = g.GameState == GameState.BlueInTurn ?
        //                g.GuessNumbers.AsQueryable()
        //                .Where(guess => guess.PlayerID == g.RedPlayerID)
        //                .Select(GuessNumberDataModel.FromGuess) :
        //                g.GuessNumbers.AsQueryable()
        //                .Where(guess => guess.PlayerID == g.BluePlayerID)
        //                .Select(GuessNumberDataModel.FromGuess),
        //            YourColor = g.GameState == GameState.RedInTurn ? "red" : "blue",
        //            GameState = g.GameState
        //        };
        //    }
        //}

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string Red { get; set; }

        [Required]
        public string Blue { get; set; }

        [MinLength(4)]
        [MaxLength(4)]
        public string YourNumber { get; set; }

        public virtual IEnumerable<GuessNumberDataModel> YourGuesses
        {
            get
            {
                return this.yourGuesses;
            }

            set
            {
                this.yourGuesses = value;
            }
        }

        public virtual IEnumerable<GuessNumberDataModel> OpponentGuesses
        {
            get
            {
                return this.opponentGuesses;
            }

            set
            {
                this.opponentGuesses = value;
            }
        }

        [Required]
        public string YourColor { get; set; }

        [Required]
        public GameState GameState { get; set; }
    }
}