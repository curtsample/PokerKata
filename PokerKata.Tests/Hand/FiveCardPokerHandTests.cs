using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerKata.Tests {
   [TestClass]
   public class FiveCardPokerHandTests {
      [TestMethod]
      public void HasRoyalFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithRoyalFlush, true),
            new TestData(HandHelpers.HandWithStraightFlush, false),
            new TestData(HandHelpers.HandWithFlush, false),
            new TestData(HandHelpers.HandWithStraight, false),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasRoyalFlush());
      }

      [TestMethod]
      public void HasStraightFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithStraightFlush, true),
            new TestData(HandHelpers.HandWithFlush, false),
            new TestData(HandHelpers.HandWithStraight, false),
            new TestData(HandHelpers.HandWithNothing, false),
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasStraightFlush());
      }

      [TestMethod]
      public void HasFourOfAKind_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithFourOfAKind, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasFourOfAKind());
      }

      [TestMethod]
      public void HasFullHouse_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithFullHouse, true),
            new TestData(HandHelpers.HandWithThreeOfAKind, false),
            new TestData(HandHelpers.HandWithPair, false),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasFullHouse());
      }

      [TestMethod]
      public void HasFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithFlush, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasFlush());
      }

      [TestMethod]
      public void HasStraight_Success() {
         // arrange


         var testData = new[] {
            new TestData(HandHelpers.HandWithStraight, true),
            new TestData(HandHelpers.HandWithAceLowStraight, true),
            new TestData(HandHelpers.HandWithAceLowNotQuiteStraight, false),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasStraight());
      }      

      [TestMethod]
      public void HasTwoPair_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithTwoPair, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasTwoPair());
      }

      [TestMethod]
      public void HasThreeOfAKind_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithThreeOfAKind, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasThreeOfAKind());
      }

      [TestMethod]
      public void HasPair_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithPair, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasPair());
      }

      [TestMethod]
      public void GetPairedCards_Success() {
         // arrange
         var pairedTestData = new[] {
            new PairedTestData(HandHelpers.HandWithFourOfAKind, 4),
            new PairedTestData(HandHelpers.HandWithThreeOfAKind, 3),
            new PairedTestData(HandHelpers.HandWithPair, 2),
            new PairedTestData(HandHelpers.HandWithNothing, 0)
         };

         // act & assert
         foreach (var test in pairedTestData) {
            Assert.AreEqual(test.ExpectedResult, test.Hand.GetPairedCards().Count());
         }
      }

      [TestMethod]
      public void FiveCardPokerHand_WithInvalidNumberOfCardsProvided_Throws() {
         // arrange
         var threeCards = new List<Card> {
            new Card(Rank.Five, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs)            
         };

         var sevenCards = new List<Card> {
            new Card(Rank.Five, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Eight, Suit.Clubs),
            new Card(Rank.Nine, Suit.Clubs),
            new Card(Rank.Ten, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs)
         };

         var invalidHands = new[] { threeCards, sevenCards };

         foreach(var invalidHand in invalidHands) {
            try {
               new FiveCardPokerHand(invalidHand);
            }
            catch(InvalidFiveCardHandException ex) {
               Assert.AreEqual(invalidHand.Count, ex.NumberOfCards);
            }
         }
      }

      private void AssertTestData(TestData[] testData, Func<FiveCardPokerHand, bool> action) {
         foreach(var test in testData) {
            Assert.AreEqual(test.ExpectedResult, action.Invoke(test.Hand));
         }
      }

      private class PairedTestData {
         public FiveCardPokerHand Hand { get; private set; }
         public int ExpectedResult { get; private set; }

         public PairedTestData(FiveCardPokerHand hand, int expectedResult) {
            Hand = hand;
            ExpectedResult = expectedResult;
         }
      }

      private class TestData {
         public FiveCardPokerHand Hand { get; private set; }
         public bool ExpectedResult { get; private set; }

         public TestData(FiveCardPokerHand hand, bool expectedResult) {
            Hand = hand;
            ExpectedResult = expectedResult;
         }
      }
   }
}
