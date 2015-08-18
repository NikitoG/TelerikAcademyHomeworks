using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardMustReturnstring()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.IsTrue(card.ToString() is string);
        }

        [TestMethod]
        public void CardMustReturnTostringCorrectly()
        {
            var card = new Card(CardFace.Ace, CardSuit.Spades);

            Assert.AreEqual("Ace of Spades", card.ToString());
        }
    }
}
