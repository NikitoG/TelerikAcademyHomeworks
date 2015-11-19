namespace SortingHomeworkTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void MethodShouldReturnTrueWhenItemExists()
        {
            var collection = new SortableCollection<int>(new[] { 52, 111, 33, 33, 46, 1125, 1 });

            Assert.IsTrue(collection.BinarySearch(111));
            Assert.IsTrue(collection.BinarySearch(52));
            Assert.IsTrue(collection.BinarySearch(33));
            Assert.IsTrue(collection.BinarySearch(46));
            Assert.IsTrue(collection.BinarySearch(1125));
            Assert.IsTrue(collection.BinarySearch(1));
        }

        [TestMethod]
        public void MethodShouldReturnFalseWhenItemDoesnotExists()
        {
            var collection = new SortableCollection<int>(new[] { 52, 111, 33, 33, 46, 1125, 1 });

            Assert.IsFalse(collection.BinarySearch(1111));
            Assert.IsFalse(collection.BinarySearch(-52));
            Assert.IsFalse(collection.BinarySearch(0));
        }
    }
}
