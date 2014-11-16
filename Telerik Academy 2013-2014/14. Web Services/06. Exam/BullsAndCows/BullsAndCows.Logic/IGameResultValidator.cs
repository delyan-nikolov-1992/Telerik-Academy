namespace BullsAndCows.Logic
{
    public interface IGameResultValidator
    {
        GameResult GetResult(string number);
    }
}