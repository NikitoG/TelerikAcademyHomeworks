

namespace RotatingWalkInMatrix.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using System.IO;
    using System.Text;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatrixShouldThrowWhenSizeIsNotGreaterThanZero()
        {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        public void MatrixShouldFillCorrectly()
        {
            Matrix testMatrix = new Matrix(6);
            string expected = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n",
                "  1 16 17 18 19 20",
                " 15  2 27 28 29 21",
                " 14 31  3 26 30 22",
                " 13 36 32  4 25 23",
                " 12 35 34 33  5 24",
                " 11 10  9  8  7  6");


            Assert.AreEqual(testMatrix.ToString(), expected);
        }
    }
}
