namespace Poker.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class PokerHandsChekerTests
    {
        [TestMethod]
        public void PokerHandsIsValidReturnTrueWhenHandIsValid()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void PokerHandsIsValidReturnFalseWhenHaveSameCards()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(!checker.IsValidHand(hand));
        }

        [TestMethod]
        public void PokerHandsIsValidReturnФалсеWhenCardIsMore()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(!checker.IsValidHand(hand));
        }

        [TestMethod]
        public void PokerHandsIsFlushReturnTrueWhenHaveFiveCardOfTheSameSuit()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void PokerHandsIsFlushReturnFalseWhenCardisOfTheDifferentSuit()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(!checker.IsFlush(hand));
        }

        [TestMethod]
        public void PokerHandsIsFourOfAKindReturnTrueWhenHaveFourOfKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void PokerHandsIsFourOfAKindReturnFalseWhenHaveNotFourOfKind()
        {
            IHand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            var checker = new PokerHandsChecker();
            Assert.IsTrue(!checker.IsFourOfAKind(hand));
        }
    }
}
