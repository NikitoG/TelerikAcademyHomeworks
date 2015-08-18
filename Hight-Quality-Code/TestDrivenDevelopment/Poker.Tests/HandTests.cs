namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandToStringMustReturnString()
        {
            var cards = new List<ICard>()
                {
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.Four, CardSuit.Hearts),
                    new Card(CardFace.Queen, CardSuit.Spades),
                    new Card(CardFace.Nine, CardSuit.Spades),
                    new Card(CardFace.Four, CardSuit.Diamonds)
                };
            var hand = new Hand(cards);

            Assert.IsTrue(hand.ToString() is string);
        }
        
        [TestMethod]
        public void HandToStringReturnCorrectly()
        {
            var cards = new List<ICard>
                {
                    new Card(CardFace.Ace, CardSuit.Clubs),
                    new Card(CardFace.Four, CardSuit.Hearts),
                };

            var hand = new Hand(cards);

            Assert.AreEqual("Ace of Clubs | Four of Hearts", hand.ToString());
        }
    }
}
