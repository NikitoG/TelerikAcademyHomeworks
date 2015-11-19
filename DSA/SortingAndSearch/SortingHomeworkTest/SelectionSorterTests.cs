namespace SortingHomeworkTest
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class SelectionSorterTests
    {
        [TestMethod]
        public void MethodShouldSortCorrectlyCollectionWithPossitiveNumbers()
        {
            var collection = new SortableCollection<int>(new[] { 52, 111, 33, 33, 46, 1125, 1 });
            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void MethodShouldSortCorrectlyCollectionWithNegativeNumbers()
        {
            var collection = new SortableCollection<int>(new[] { -52, -111, -33, -33, -46, -1125, -1 });
            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void MethodShouldSortCorrectlyCollectionWithEqualElements()
        {
            var collection = new SortableCollection<int>(new[] { 5, 5, 5, 5 });
            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }

        [TestMethod]
        public void MethodShouldSortCorrectlyCollection()
        {
            var collection = new SortableCollection<int>(new[] { 52, -111, -33, 33, -46, 0, -1 });
            collection.Sort(new SelectionSorter<int>());

            for (int i = 0; i < collection.Items.Count - 1; i++)
            {
                Assert.IsTrue(collection.Items[i].CompareTo(collection.Items[i + 1]) <= 0);
            }
        }
    }
}
