using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RotatingWalkInMatrix.Tests
{
    [TestClass]
    public class CellTests
    {

        [TestMethod]
        public void AddingTwoCellsShouldReturnANewCellAndNotToThow()
        {
            Cell resultingCell = new Cell(1, 2) + new Cell(2, 1);

            Assert.AreEqual(3, resultingCell.Row);
            Assert.AreEqual(3, resultingCell.Col);
        }
    }
}
