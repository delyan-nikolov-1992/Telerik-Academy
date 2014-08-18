namespace TestMatrix
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RotatingWalkInMatrix;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindingTheFirstEmptyCellInMatrix()
        {
            int[,] handFilledMatrix = { 
                                        { 1, 16, 17, 18, 19, 20 },
                                        { 15, 2, 27, 28, 29, 21 },
                                        { 14, 31, 3, 26, 30, 22 },
                                        { 13, 36, 32, 4, 25, 23 },
                                        { 12, 35, 34, 33, 5, 24 },
                                        { 11, 10, 9, 8, 7, 6 }
                                      };
            int[,] autoFilledMatrix = Matrix.FillMatrix(6);

            Assert.AreEqual(
                handFilledMatrix.ToString(),
                autoFilledMatrix.ToString(),
                string.Format("Expected output: {0}\nActual output: {1}", handFilledMatrix, autoFilledMatrix));
        }
    }
}