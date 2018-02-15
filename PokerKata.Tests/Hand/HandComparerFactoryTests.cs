using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   [TestClass]
   public class HandComparerFactoryTests {
      private HandComparerFactory _factory;

      [TestInitialize]
      public void BeforeEach() {
         _factory = new HandComparerFactory();
      }

      [TestMethod]
      public void GetComparer_Success() {
         // arrange
         var testData = new[] {
            new { Rank = HandRank.StraightFlush, ExpectedType = typeof(HighestRankComparer) },
            new { Rank = HandRank.Flush, ExpectedType = typeof(HighestRankComparer) },
            new { Rank = HandRank.Straight, ExpectedType = typeof(HighestRankComparer) },
            new { Rank = HandRank.FourOfAKind, ExpectedType = typeof(PairedCardComparer) },
            new { Rank = HandRank.ThreeOfAKind, ExpectedType = typeof(PairedCardComparer) },
            new { Rank = HandRank.Pair, ExpectedType = typeof(PairedCardComparer) },
         };

         // act & assert
         foreach (var test in testData) {
            Assert.IsInstanceOfType(_factory.GetComparer(test.Rank), test.ExpectedType);
         }         
      }
   }
}
