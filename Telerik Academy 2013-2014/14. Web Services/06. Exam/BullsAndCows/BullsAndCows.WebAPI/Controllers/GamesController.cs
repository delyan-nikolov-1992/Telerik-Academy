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

    public class GamesController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        private IGameResultValidator resultValidator;

        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
            this.resultValidator = new GameResultValidator();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.GetWithDetails(0);
            }

            return this.Get(0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.GetWithDetails(page);
            }

            var games = this.GetGamesWithOnePlayerSorted()
                .Skip(page * DefaultPageSize)
                .Take(DefaultPageSize);

            // no games that are in state available for joining
            if (games.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(games);
        }

        [HttpGet]
        [Authorize]
        private IHttpActionResult GetWithDetails(int page)
        {
            var userID = this.User.Identity.GetUserId();

            var games = this.GetGamesWithDetailsSorted(userID)
                .Skip(page * DefaultPageSize)
                .Take(DefaultPageSize);

            // No games where:
            // the authenticated user is part of and are not finished yet OR
            // are available for joining, meaning that a blue player has yet to join the game
            if (games.Count() == 0)
            {
                return this.NotFound();
            }

            return this.Ok(games);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetByID(int id)
        {
            var userID = this.User.Identity.GetUserId();

            var game = this.Data.Games.Find(id);

            if (game == null ||
                (game.GameState != GameState.RedInTurn && game.GameState != GameState.BlueInTurn) ||
                (game.RedPlayerID != userID && game.BluePlayerID != userID))
            {
                return this.NotFound();
            }

            var gameModel = new GameDetailsDataModels(game);

            return this.Ok(gameModel);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(CreateRequestDataModel request)
        {
            string number = request.Number;

            if (!IsValidNumber(number))
            {
                return this.BadRequest("The number should consist of the digits 0-9, with no repeating digits!");
            }

            var userID = this.User.Identity.GetUserId();

            var newGame = new Game
            {
                Name = request.Name,
                RedPlayerID = userID,
                RedPlayerNumber = number,
                GameState = GameState.WaitingForOpponent,
                DateCreated = DateTime.Now,
            };

            this.Data.Games.Add(newGame);
            this.Data.SaveChanges();

            var game = new GameDataModel
            {
                Id = newGame.Id,
                Name = newGame.Name,
                Blue = "No blue player yet",
                Red = this.User.Identity.GetUserName(),
                GameState = newGame.GameState,
                DateCreated = newGame.DateCreated
            };

            return Ok(game);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(JoinRequestDataModel request)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var game = this.Data.Games
                .All()
                .Where(g => g.GameState == GameState.WaitingForOpponent && g.RedPlayerID != currentUserId)
                .FirstOrDefault();

            if (game == null)
            {
                return NotFound();
            }

            game.BluePlayerID = currentUserId;
            game.BluePlayerNumber = request.Number;
            var onTurn = this.Random.GetRandomInt(0, 1);
            game.GameState = onTurn == 0 ? GameState.RedInTurn : GameState.BlueInTurn;

            var notification = new Notification
            {
                Message = string.Format("{0} joined your game \"{1}\"", game.BluePlayer.UserName, game.Name),
                DateCreated = DateTime.Now,
                MessageType = MessageType.GameJoined,
                MessageState = MessageState.Unread,
                GameID = game.Id,
                PlayerID = game.RedPlayerID
            };

            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();

            var response = new JoinResponseDataModel
            {
                Result = string.Format("You joined game \"{0}\"", game.Name)
            };

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Play(int id, JoinRequestDataModel request)
        {
            var currentUserId = this.User.Identity.GetUserId();

            if (request == null || !ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return this.BadRequest("Invalid game id!");
            }

            if (game.RedPlayerID != currentUserId &&
                game.BluePlayerID != currentUserId)
            {
                return this.BadRequest("This is not your game!");
            }

            if (game.GameState != GameState.RedInTurn &&
                game.GameState != GameState.BlueInTurn)
            {
                return this.BadRequest("Invalid game state!");
            }

            if ((game.GameState == GameState.RedInTurn &&
                game.RedPlayerID != currentUserId)
                ||
                (game.GameState == GameState.BlueInTurn &&
                game.BluePlayerID != currentUserId))
            {
                return this.BadRequest("It's not your turn!");
            }

            var number = request.Number;

            if (!IsValidNumber(number))
            {
                return this.BadRequest("The number should consist of the digits 0-9, with no repeating digits!");
            }

            var gameResult = resultValidator.GetResult(number);

            var guessNumber = new GuessNumber
            {
                PlayerID = currentUserId,
                GameID = game.Id,
                Number = number,
                DateMade = DateTime.Now,
                CowsCount = gameResult.Cows,
                BullsCount = gameResult.Bulls

            };

            this.Data.GuessNumbers.Add(guessNumber);
            this.Data.SaveChanges();

            switch (gameResult.GameResultType)
            {
                case GameResultType.NotFinished:
                    SendMessageForTurn(game);
                    break;
                case GameResultType.WonByRed:
                    game.GameState = GameState.WonByRedPlayer;
                    this.Data.SaveChanges();
                    SendMessageForWin(game);
                    break;
                case GameResultType.WonByBlue:
                    game.GameState = GameState.WonByBluePlayer;
                    this.Data.SaveChanges();
                    SendMessageForWin(game);
                    break;
                default:
                    break;
            }

            return this.Ok(guessNumber);
        }

        private void SendMessageForTurn(Game game)
        {
            var notification = new Notification
            {
                Message = string.Format("It is your turn in game \"{0}\"", game.Name),
                DateCreated = DateTime.Now,
                MessageType = MessageType.YourTurn,
                MessageState = MessageState.Unread,
                GameID = game.Id,
                PlayerID = game.GameState == GameState.RedInTurn ? game.RedPlayerID : game.BluePlayerID
            };

            this.Data.Notifications.Add(notification);
            this.Data.SaveChanges();
        }

        private void SendMessageForWin(Game game)
        {
            var notificationWinner = new Notification
            {
                Message = string.Format(
                    "You beat {0} in game \"{1}\"",
                    game.GameState == GameState.WonByBluePlayer ? game.RedPlayer.UserName : game.BluePlayer.UserName,
                    game.Name),
                DateCreated = DateTime.Now,
                MessageType = MessageType.GameLost,
                MessageState = MessageState.Unread,
                GameID = game.Id,
                PlayerID = game.GameState == GameState.WonByBluePlayer ? game.BluePlayerID : game.RedPlayerID
            };

            var notificationLooser = new Notification
            {
                Message = string.Format(
                    "{0} beat you in game \"{1}\"",
                    game.GameState == GameState.WonByBluePlayer ? game.BluePlayer.UserName : game.RedPlayer.UserName,
                    game.Name),
                DateCreated = DateTime.Now,
                MessageType = MessageType.GameLost,
                MessageState = MessageState.Unread,
                GameID = game.Id,
                PlayerID = game.GameState == GameState.WonByBluePlayer ? game.RedPlayerID : game.BluePlayerID
            };

            this.Data.Notifications.Add(notificationWinner);
            this.Data.Notifications.Add(notificationLooser);
            this.Data.SaveChanges();
        }

        private IEnumerable<GameDataModel> GetGamesWithOnePlayerSorted()
        {
            return this.Data.Games.All()
                .Where(g => g.GameState == GameState.WaitingForOpponent)
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Select(GameDataModel.FromGame);
        }

        private IEnumerable<GameDataModel> GetGamesWithDetailsSorted(string playerId)
        {
            return this.Data.Games.All()
                .Where(g => ((g.RedPlayerID == playerId || g.BluePlayerID == playerId) &&
                    (g.GameState == GameState.RedInTurn || g.GameState == GameState.BlueInTurn)) ||
                    (g.GameState == GameState.WaitingForOpponent))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Select(GameDataModel.FromGame);
        }

        private bool IsValidNumber(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (!char.IsDigit(number[i]))
                {
                    return false;
                }

                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[i] == number[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}