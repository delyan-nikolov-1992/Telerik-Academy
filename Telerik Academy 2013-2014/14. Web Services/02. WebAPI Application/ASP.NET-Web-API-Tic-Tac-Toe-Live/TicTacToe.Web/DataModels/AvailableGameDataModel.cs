namespace TicTacToe.Web.DataModels
{
    using System;
    using System.Linq.Expressions;

    using TicTacToe.Models;

    public class AvailableGameDataModel
    {
        public static Expression<Func<Game, AvailableGameDataModel>> FromGame
        {
            get
            {
                return g => new AvailableGameDataModel
                {
                    Id = g.Id.ToString(),
                    FirstPlayerUsername = g.FirstPlayer.UserName
                };
            }
        }

        public string Id { get; set; }

        public string FirstPlayerUsername { get; set; }
    }
}