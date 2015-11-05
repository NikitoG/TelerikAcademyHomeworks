namespace HashTableAndSetTests
{
    using System;
    using System.Collections.Generic;

    using HashSetImplementation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    
    [TestClass]
    public class HashSetTests
    {
        [TestMethod]
        public void AddShouldNotThrowExceptionWhenAddSameElement()
        {
            var set = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                set.Add("pesho");
            }

            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void CountShouldReturnCorrectResult()
        {
            var set = new HashedSet<string>();

            Assert.AreEqual(0, set.Count);
            for (int i = 0; i < 20; i++)
            {
                set.Add(string.Format("pesho #{0}", i % 5));
            }

            Assert.AreEqual(5, set.Count);
        }

        [TestMethod]
        public void ContainsShouldReturnCorrectResult()
        {
            var set = new HashedSet<string>();

            for (int i = 0; i < 20; i++)
            {
                set.Add(string.Format("pesho #{0}", i % 5));
            }

            Assert.IsTrue(set.Contains("pesho #3"));
            Assert.IsFalse(set.Contains("pesho #13"));
        }

        [TestMethod]
        public void RemoveShouldDeleteElementCorrectly()
        {
            var set = new HashedSet<string>();

            for (int i = 0; i < 20; i++)
            {
                set.Add(string.Format("pesho #{0}", i % 5));
            }

            set.Remove("pesho #3");

            Assert.AreEqual(4, set.Count);
            Assert.IsFalse(set.Contains("pesho #3"));
        }

        [TestMethod]
        public void ClearShouldWorkCorrectly()
        {
            var set = new HashedSet<string>();

            for (int i = 0; i < 20; i++)
            {
                set.Add(string.Format("pesho #{0}", i % 5));
            }

            set.Clear();
            Assert.AreEqual(0, set.Count);
            for (int i = 0; i < 4; i++)
            {
                Assert.IsFalse(set.Contains(string.Format("pesho #{0}", i)));
            }
        }

        [TestMethod]
        public void UnionShouldReturnSetWithElementsFromBothSets()
        {
            var firstSet = new HashedSet<int>();
            var secondSet = new HashedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                if (i < 7)
                {
                    firstSet.Add(i);
                }

                if (i > 3)
                {
                    secondSet.Add(i);
                }
            }

            var result = firstSet.UnionWith(secondSet);

            Assert.AreEqual(10, result.Count);

            foreach (var item in result)
            {
                Assert.IsTrue(item >= 0 && item < 10);
            }
        }

        [TestMethod]
        public void IntersectShouldReturnSetWithElementsDoubledElelemt()
        {
            var firstSet = new HashedSet<int>();
            var secondSet = new HashedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                if (i < 7)
                {
                    firstSet.Add(i);
                }

                if (i > 3)
                {
                    secondSet.Add(i);
                }
            }

            var result = firstSet.IntersectWith(secondSet);

            Assert.AreEqual(3, result.Count);

            foreach (var item in result)
            {
                Assert.IsTrue(item >= 3 && item < 7);
            }
        }

        [TestMethod]
        public void EnumeratorShouldWorkCorrectly()
        {
            var set = new HashedSet<int>();
            for (int i = 0; i < 10; i++)
            {
                set.Add(i);
            }

            foreach (var item in set)
            {
                Assert.IsTrue(item >= 0 && item < 10);
            }
        }

        [TestMethod]
        public void AddShouldSaveElementsWithDifferentKeysAndSameHashCode()
        {
            var firstElement = new Mock<IConvertible>();
            firstElement.Setup(x => x.GetHashCode()).Returns(8);
            var secondElement = new Mock<IConvertible>();
            secondElement.Setup(x => x.GetHashCode()).Returns(8);

            var set = new HashedSet<IConvertible>();
            set.Add(firstElement.Object);
            set.Add(secondElement.Object);

            Assert.AreEqual(2, set.Count);
            Assert.IsTrue(set.Contains(firstElement.Object));
            Assert.IsTrue(set.Contains(secondElement.Object));
        }
    }
}
