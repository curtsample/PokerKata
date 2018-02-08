using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   [TestClass]
   public class FiveCardHandEvaluatorTests {
      private readonly FiveCardHandEvaluator _evaluator = new FiveCardHandEvaluator();

      [TestMethod]
      public void Evaluate_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithRoyalFlush, HandRank.RoyalFlush),
            new TestData(HandHelpers.HandWithStraightFlush, HandRank.StraightFlush),
            new TestData(HandHelpers.HandWithFourOfAKind, HandRank.FourOfAKind),
            new TestData(HandHelpers.HandWithFullHouse, HandRank.FullHouse),
            new TestData(HandHelpers.HandWithFlush, HandRank.Flush),
            new TestData(HandHelpers.HandWithStraight, HandRank.Straight),
            new TestData(HandHelpers.HandWithThreeOfAKind, HandRank.ThreeOfAKind),
            new TestData(HandHelpers.HandWithTwoPair, HandRank.TwoPair),
            new TestData(HandHelpers.HandWithPair, HandRank.Pair),
            new TestData(HandHelpers.HandWithNothing, HandRank.HighCard)
         };

         // act & assert
         AssertTestData(testData);
      }

      private void AssertTestData(TestData[] testData) {
         foreach (var test in testData) {
            Assert.AreEqual(test.ExpectedResult, _evaluator.Evaluate(test.Hand));
         }
      }

      private class TestData {
         public FiveCardPokerHand Hand { get; private set; }
         public HandRank ExpectedResult { get; private set; }

         public TestData(FiveCardPokerHand hand, HandRank expectedResult) {
            Hand = hand;
            ExpectedResult = expectedResult;
         }
      }
   }
}
