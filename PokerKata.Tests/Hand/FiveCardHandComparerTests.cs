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
         _comparer = new FiveCardHandComparer(new FiveCardHandEvaluator(), new HandComparerFactory());
      }

      [TestMethod]
      public void Compare_WithDifferentHandRanks_Success() {
         // arrange
         var testData = new[] {
            new HandCompareTestData(HandHelpers.HandWithRoyalFlush, HandHelpers.HandWithStraightFlush, HandCompareResult.FirstHandWins),
            new HandCompareTestData(HandHelpers.HandWithFourOfAKind, HandHelpers.HandWithStraightFlush, HandCompareResult.SecondHandWins),
            new HandCompareTestData(HandHelpers.HandWithFourOfAKind, HandHelpers.HandWithFullHouse, HandCompareResult.FirstHandWins),
            new HandCompareTestData(HandHelpers.HandWithFlush, HandHelpers.HandWithFullHouse, HandCompareResult.SecondHandWins),
            new HandCompareTestData(HandHelpers.HandWithFlush, HandHelpers.HandWithStraight, HandCompareResult.FirstHandWins),
            new HandCompareTestData(HandHelpers.HandWithThreeOfAKind, HandHelpers.HandWithStraight, HandCompareResult.SecondHandWins),
            new HandCompareTestData(HandHelpers.HandWithThreeOfAKind, HandHelpers.HandWithTwoPair, HandCompareResult.FirstHandWins),
            new HandCompareTestData(HandHelpers.HandWithPair, HandHelpers.HandWithTwoPair, HandCompareResult.SecondHandWins),
            new HandCompareTestData(HandHelpers.HandWithPair, HandHelpers.HandWithNothing, HandCompareResult.FirstHandWins)
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
   }
}
