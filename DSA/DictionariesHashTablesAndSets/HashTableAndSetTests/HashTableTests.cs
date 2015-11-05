namespace HashTableAndSetTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using HashTableImplementation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void NewInstanceShouldHaveCounZeroAndNotToThrow()
        {
            var table = new HashTable<string, int>();
            var keys = table.Keys;

            Assert.AreEqual(0, table.Count);
            Assert.AreEqual(0, keys.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddShouldThrowArgumentExceptionWhenKeyExist()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);
            table.Add("pesho", 3);
        }

        [TestMethod]
        public void CountShouldReturnCorrectResult()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);
            table.Add("gosho", 3);
            table.Add("stamat", 3);
            table.Remove("gosho");

            Assert.AreEqual(2, table.Count);
        }

        [TestMethod]
        public void KeysShouldReturnCorrectResult()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);
            table.Add("gosho", 3);
            table.Add("stamat", 3);
            table.Remove("gosho");

            var keys = table.Keys;

            Assert.IsTrue(keys.Contains("pesho"));
            Assert.IsFalse(keys.Contains("gosho"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void WhenTryToGetUnexistingIndexShouldTrowKeyNotFoundException()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);
            var item = table["gosho"];
        }

        [TestMethod]
        public void AddingByIndexShouldAddCorrectly()
        {
            var table = new HashTable<string, int>();
            table["pesho"] = 2;

            Assert.AreEqual(2, table["pesho"]);
        }

        [TestMethod]
        public void WhenHashTableLoadRunsOver75ProcentageShouldResize()
        {
            var table = new HashTable<int, int>();
            Assert.AreEqual(16, table.Capacity);

            for (int i = 1; i < 14; i++)
            {
                table.Add(i, i);
            }

            Assert.AreEqual(32, table.Capacity);
        }

        [TestMethod]
        public void ClearShouldDeleteAllItems()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);
            table.Add("gosho", 3);
            table.Add("stamat", 3);

            table.Clear();
            var keys = table.Keys;
            var value = 0;

            Assert.AreEqual(0, table.Count);
            Assert.AreEqual(0, keys.Count);
            Assert.IsFalse(table.Find("pesho", out value));
            Assert.IsFalse(table.Find("gosho", out value));
            Assert.IsFalse(table.Find("stamat", out value));
        }

        [TestMethod]
        public void ContainsKeyShouldReturnCorrectResult()
        {
            var table = new HashTable<string, int>();
            table.Add("pesho", 2);

            Assert.IsTrue(table.ContainsKey("pesho"));
            Assert.IsFalse(table.ContainsKey("gosho"));
        }

        [TestMethod]
        public void AddShouldSaveElementsWithDifferentKeysAndSameHashCode()
        {
            var firstElement = new Mock<IConvertible>();
            firstElement.Setup(x => x.GetHashCode()).Returns(8);
            var secondElement = new Mock<IConvertible>();
            secondElement.Setup(x => x.GetHashCode()).Returns(8);

            var table = new HashTable<IConvertible, int>();
            table.Add(firstElement.Object, 2);
            table.Add(secondElement.Object, 3);

            Assert.AreEqual(2, table[firstElement.Object]);
            Assert.AreEqual(3, table[secondElement.Object]);
        }

        [TestMethod]
        public void EnumeratorShouldWorkCorrectly()
        {
            var keys = new string[] { "pesho", "osho", "stamat" };

            var table = new HashTable<string, int>();

            for (int i = 0; i < keys.Length; i++)
            {
                table.Add(keys[i], i + 1);
            }

            foreach (var item in table)
            {
                Assert.IsTrue(keys.Contains(item.Key));
            }
        }
    }
}
