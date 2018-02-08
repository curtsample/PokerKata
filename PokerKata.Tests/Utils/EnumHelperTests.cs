using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokerKata.Utils;

namespace PokerKata.Tests.Cards {
   [TestClass]
   public class EnumHelperTests {
      private const int NUMBER_OF_RANKS = 13;
      private const int NUMBER_OF_SUITS = 4;
      private const int NUMBER_OF_HAND_RANKS = 10;

      [TestMethod]
      public void GetRanks_ReturnsAllRanks() =>
         Assert.AreEqual(NUMBER_OF_RANKS, EnumHelpers.GetValues<Rank>().Count());      

      [TestMethod]
      public void GetSuits_ReturnsAllRanks() =>
         Assert.AreEqual(NUMBER_OF_SUITS, EnumHelpers.GetValues<Suit>().Count());

      [TestMethod]
      public void GetHandRanks_ReturnsAllHandRanks() =>
         Assert.AreEqual(NUMBER_OF_HAND_RANKS, EnumHelpers.GetValues<HandRank>().Count());
   }
}
