namespace Santase.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Santase.Logic.Cards;
    using System.Collections.Generic;

    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void ExpectedToCreateDeckWithTwentyFourCatds()
        {
            var deck = new Deck();

            Assert.AreEqual(deck.CardsLeft, 24);
        }

        [Test]
        public void ExpectedAllCardsInDeckAreDifferent()
        {
            var deck = new Deck();
            var hasDupes = false;
            var dupesDeck = new List<Card>();

            for (int i = 0; i < deck.CardsLeft; i++)
            {
                if (dupesDeck.Contains(deck.GetNextCard()))
                {
                    hasDupes = true;
                    break;
                }
            }
            Assert.False(hasDupes);
        }

        [Test]
        [ExpectedException]
        public void DeckShouldThrowWhenGetCardAndDeckIsEmpty()
        {
            var deck = new Deck();

            for (int i = 0; i <= 25; i++)
            {
                deck.GetNextCard();
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(12)]
        [TestCase(18)]
        public void DeckShouldUpdateCardsLeftCorrectly(int count)
        {
            var deck = new Deck();

            for (int i = 0; i < count; i++)
            {
                deck.GetNextCard();
            }

            Assert.AreEqual(24 - count, deck.CardsLeft);
        }
    }
}
