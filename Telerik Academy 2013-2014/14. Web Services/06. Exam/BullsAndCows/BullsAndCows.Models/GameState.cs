namespace BullsAndCows.Models
{
    public enum GameState
    {
        WaitingForOpponent = 0,
        RedInTurn = 1,
        BlueInTurn = 2,
        WonByRedPlayer = 3,
        WonByBluePlayer = 4
    }
}