namespace TicTacToe.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using TicTacToe.GameLogic;

    [TestClass]
    public class GameResultValidatorTest
    {
        private static IGameResultValidator resultValidator = new GameResultValidator();

        [TestMethod]
        public void TestGameThatIsNotFinished()
        {
            GameResult expectedGameResult = resultValidator.GetResult("X--------");
            GameResult actualGameResult = GameResult.NotFinished;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsXByRow()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XXX-O---O");
            GameResult actualGameResult = GameResult.WonByX;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsOByRow()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XX-OOO-XX");
            GameResult actualGameResult = GameResult.WonByO;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsXByCol()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XOOX--X--");
            GameResult actualGameResult = GameResult.WonByX;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsOByCol()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XO-XO--OX");
            GameResult actualGameResult = GameResult.WonByO;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsXByMainDiagonal()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XO-OX--OX");
            GameResult actualGameResult = GameResult.WonByX;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsXByMinorDiagonal()
        {
            GameResult expectedGameResult = resultValidator.GetResult("O-XOX-X-O");
            GameResult actualGameResult = GameResult.WonByX;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsOByMainDiagonal()
        {
            GameResult expectedGameResult = resultValidator.GetResult("OX-XO--XO");
            GameResult actualGameResult = GameResult.WonByO;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatWinnerIsOByMinorDiagonal()
        {
            GameResult expectedGameResult = resultValidator.GetResult("X-OXO-O-X");
            GameResult actualGameResult = GameResult.WonByO;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }

        [TestMethod]
        public void TestGameThatIsDraw()
        {
            GameResult expectedGameResult = resultValidator.GetResult("XOXXXOOXO");
            GameResult actualGameResult = GameResult.Draw;

            Assert.AreEqual(
                expectedGameResult,
                actualGameResult,
                string.Format("Expected game result: {0}\nActual game result: {1}", expectedGameResult, actualGameResult));
        }
    }
}