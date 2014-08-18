public class Coordinates
{
    // second task - second if statement
    private const double MIN_X_COORD = double.MinValue;
    private const double MIN_Y_COORD = double.MinValue;
    private const double MAX_X_COORD = double.MaxValue;
    private const double MAX_Y_COORD = double.MaxValue;

    private void CheckCell()
    {
        double xCoord;
        double yCoord;

        if (xCoord >= MIN_X_COORD && (xCoord <= MAX_X_COORD && ((MAX_Y_COORD >= y_Coord && MIN_Y_COORD <= yCoord)
            && !shouldNotVisitCell)))
        {
            VisitCell();
        }
    }
}