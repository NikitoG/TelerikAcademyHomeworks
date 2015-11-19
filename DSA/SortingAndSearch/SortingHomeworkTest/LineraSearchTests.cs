namespace SortingHomeworkTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class LineraSearchTests
    {
        [TestMethod]
        public void MethodShouldReturnTrueWhenItemExists()
        {
            var collection = new SortableCollection<int>(new[] { 52, 111, 33, 33, 46, 1125, 1 });

            Assert.IsTrue(collection.LinearSearch(111));
            Assert.IsTrue(collection.LinearSearch(52));
            Assert.IsTrue(collection.LinearSearch(33));
            Assert.IsTrue(collection.LinearSearch(46));
            Assert.IsTrue(collection.LinearSearch(1125));
            Assert.IsTrue(collection.LinearSearch(1));
        }

        [TestMethod]
        public void MethodShouldReturnFalseWhenItemDoesnotExists()
        {
            var collection = new SortableCollection<int>(new[] { 52, 111, 33, 33, 46, 1125, 1 });

            Assert.IsFalse(collection.LinearSearch(1111));
            Assert.IsFalse(collection.LinearSearch(-52));
            Assert.IsFalse(collection.LinearSearch(0));
        }
    }
}
