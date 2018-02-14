using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   [TestClass]
   public class HighestRankComparerTests {
      private HighestRankComparer _comparer;

      [TestInitialize]
      public void BeforeEach() {
         _comparer = new HighestRankComparer();
      }

      [TestMethod]
      public void Compare_WithStraightFlushes_Success() {
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

         var testData = GetTestData(winningHand, losingHand);

         // act & assert
         AssertTestData(testData);
      }

      [TestMethod]
      public void Compare_WithFlushes_Success() {
         // arrange
         var winningHand = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Two, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.King, Suit.Clubs)
         });

         var losingHand = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Two, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.Four, Suit.Clubs)
         });

         var testData = GetTestData(winningHand, losingHand);

         // act & assert
         AssertTestData(testData);
      }

      [TestMethod]
      public void Compare_WithStraights_Success() {
         // arrange
         var winningHand = new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Nine, Suit.Spades),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Seven, Suit.Diamonds),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Five, Suit.Spades)
         });

         var losingHand = new FiveCardPokerHand(new List<Card> {            
            new Card(Rank.Seven, Suit.Diamonds),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Five, Suit.Spades),
            new Card(Rank.Four, Suit.Spades),
            new Card(Rank.Three, Suit.Spades),
         });

         var testData = GetTestData(winningHand, losingHand);

         // act & assert
         AssertTestData(testData);
      }

      #region Helpers

      private void AssertTestData(TestData[] testData) {
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _comparer.Compare(test.First, test.Second));
         }
      }

      private TestData[] GetTestData(FiveCardPokerHand winningHand, FiveCardPokerHand losingHand) {
         return new[] {
            new TestData(winningHand, losingHand, HandCompareResult.FirstHandWins),
            new TestData(losingHand, winningHand, HandCompareResult.SecondHandWins),
            new TestData(winningHand, winningHand, HandCompareResult.Split)
         };
      }

      #endregion

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
