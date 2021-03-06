﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   [TestClass]
   public class PairedCardComparerTests {
      private PairedCardComparer _comparer;

      [TestInitialize]
      public void BeforeEach() {
         _comparer = new PairedCardComparer();
      }

      [TestMethod]
      public void Compare_WithFourOfAKind_Success() {
         // arrange
         var winningPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.Eight, Suit.Hearts)
         });

         var losingPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Eight, Suit.Spades),
            new Card(Rank.Eight, Suit.Diamonds),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Eight, Suit.Clubs),
            new Card(Rank.Ace, Suit.Hearts)
         });

         var winningKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.King, Suit.Hearts)
         });

         var losingKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.Eight, Suit.Hearts)
         });

         var testData = HandCompareTestData.GetTestData(winningPair, losingPair)
            .Concat(HandCompareTestData.GetTestData(winningKicker, losingKicker));

         // act & assert
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }

      [TestMethod]
      public void Compare_WithThreeOfAKind_Success() {
         // arrange
         var winningPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var losingPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Eight, Suit.Spades),
            new Card(Rank.Eight, Suit.Diamonds),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var winningKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Four, Suit.Clubs)
         });

         var losingKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var testData = HandCompareTestData.GetTestData(winningPair, losingPair)
            .Concat(HandCompareTestData.GetTestData(winningKicker, losingKicker));

         // act & assert
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }

      [TestMethod]
      public void Compare_WithPair_Success() {
         // arrange
         var winningPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var losingPair = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.King, Suit.Spades),
            new Card(Rank.King, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var winningKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var losingKicker = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Four, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

         var testData = HandCompareTestData.GetTestData(winningPair, losingPair)
            .Concat(HandCompareTestData.GetTestData(winningKicker, losingKicker));

         // act & assert
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }
   }
}
