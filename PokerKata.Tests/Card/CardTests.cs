using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PokerKata;

namespace PokerKata.Tests.Cards {
   [TestClass]
   public class CardTests {
      [TestMethod]
      public void CardToString_DisplaysExpectedText() {
         var firstCard = new Card(Rank.Ace, Suit.Spades);
         var secondCard = new Card(Rank.Queen, Suit.Hearts);

         Assert.AreEqual("Ace of Spades", firstCard.ToString());
         Assert.AreEqual("Queen of Hearts", secondCard.ToString());
      }
   }
}
