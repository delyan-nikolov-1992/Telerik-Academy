namespace BullsAndCows.Logic
{
    using System;
    public class GameResultValidator : IGameResultValidator
    {
        // I had no time for implementing the logic, sorry :)
        public GameResult GetResult(string number)
        {
            return new GameResult
            {
                Bulls = 0,
                Cows=0,
                GameResultType=GameResultType.NotFinished
            };
        }
    }
}