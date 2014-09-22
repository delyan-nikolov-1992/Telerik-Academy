namespace AllAreasOfEmptyCells
{
    public struct Position
    {
        public int Row;
        public int Col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Row, this.Col);
        }
    }
}