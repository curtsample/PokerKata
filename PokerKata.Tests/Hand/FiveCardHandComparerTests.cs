using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   [TestClass]
   public class FiveCardHandComparerTests {
      private FiveCardHandComparer _comparer;      

      [TestInitialize]
      public void BeforeEach() {
         _comparer = new FiveCardHandComparer(new FiveCardHandEvaluator());
      }

      [TestMethod]
      public void Compare_WithDifferentHandRanks_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithRoyalFlush, HandHelpers.HandWithStraightFlush, HandCompareResult.FirstHandWins),
            new TestData(HandHelpers.HandWithFourOfAKind, HandHelpers.HandWithStraightFlush, HandCompareResult.SecondHandWins),
            new TestData(HandHelpers.HandWithFourOfAKind, HandHelpers.HandWithFullHouse, HandCompareResult.FirstHandWins),
            new TestData(HandHelpers.HandWithFlush, HandHelpers.HandWithFullHouse, HandCompareResult.SecondHandWins),
            new TestData(HandHelpers.HandWithFlush, HandHelpers.HandWithStraight, HandCompareResult.FirstHandWins),
            new TestData(HandHelpers.HandWithThreeOfAKind, HandHelpers.HandWithStraight, HandCompareResult.SecondHandWins),
            new TestData(HandHelpers.HandWithThreeOfAKind, HandHelpers.HandWithTwoPair, HandCompareResult.FirstHandWins),
            new TestData(HandHelpers.HandWithPair, HandHelpers.HandWithTwoPair, HandCompareResult.SecondHandWins),
            new TestData(HandHelpers.HandWithPair, HandHelpers.HandWithNothing, HandCompareResult.FirstHandWins)
         };

         // act & assert
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }

      [TestMethod]
      [Description("Royal Flushes will always be the same, so a Split result should be returned")]
      public void Compare_WithTwoRoyalFlushes_ReturnsSplit() {
         Assert.AreEqual(HandCompareResult.Split, _comparer.Compare(HandHelpers.HandWithRoyalFlush, HandHelpers.HandWithRoyalFlush));
      }

      [TestMethod]
      [Description("With two straight flushes, the hand with the highest card wins, unless the same where a split is returned")]
      public void Compare_WithTwoStraightFlushes_Success() {
         // arrange
         var winningHand = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Nine, Suit.Clubs),
            new Card(Rank.Eight, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Five, Suit.Clubs)
         });

         var losingHand = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Five, Suit.Clubs),
            new Card(Rank.Four, Suit.Clubs),
            new Card(Rank.Three, Suit.Clubs)
         });

         var testData = new[] {
            new TestData(winningHand, losingHand, HandCompareResult.FirstHandWins),
            new TestData(losingHand, winningHand, HandCompareResult.SecondHandWins),
            new TestData(winningHand, winningHand, HandCompareResult.Split)
         };

         // act & assert
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }

      private class TestData {
         public Hand First { get; private set; }
         public Hand Second { get; private set; }
         public HandCompareResult ExpectedResult { get; private set; }

         public TestData(Hand first, Hand second, HandCompareResult expectedResult) {
            First = first;
            Second = second;
            ExpectedResult = expectedResult;
         }
      }
   }
}
