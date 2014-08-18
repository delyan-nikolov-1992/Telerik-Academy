namespace ExceptionsHandling
{
    using System;

    public class CSharpExam : Exam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (this.score < MinScore || this.score > MaxScore)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(
                            "The score for the C# exam should be between {0} and {1} inclusive!",
                            MinScore,
                            MaxScore));
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
        }
    }
}