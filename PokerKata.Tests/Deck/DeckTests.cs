using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerKata;

namespace PokerKata.Tests {
   [TestClass]
   public class DeckTests {
      private const int NUMBER_OF_CARDS_IN_FULL_DECK = 52;

      [TestMethod]
      public void NewDeck_Has52Cards() {
         Assert.AreEqual(NUMBER_OF_CARDS_IN_FULL_DECK, new Deck().NumCardsLeftInDeck);
      }

      [TestMethod]
      public void Deal_ReturnsCards() {
         var deck = new Deck();         
         
         Assert.AreEqual(1, deck.Deal().Count());
         Assert.AreEqual(2, deck.Deal(2).Count());
         Assert.AreEqual(5, deck.Deal(5).Count());
      }

      [TestMethod]
      public void Deal_RemovesCardsFromDeck() {
         // arrange
         var deck = new Deck();
         
         // act
         deck.Deal();

         // assert
         Assert.AreEqual(NUMBER_OF_CARDS_IN_FULL_DECK - 1, deck.NumCardsLeftInDeck);
      }

      [TestMethod]
      public void Deal_MultipleCards_RemovesCardsFromDeck() {
         // arrange
         var deck = new Deck();
         var cardsToDeal = 3;

         // act
         deck.Deal(cardsToDeal);

         // assert
         Assert.AreEqual(NUMBER_OF_CARDS_IN_FULL_DECK - cardsToDeal, deck.NumCardsLeftInDeck);
      }

      [TestMethod]
      [ExpectedException(typeof(DeckOutOfCardsException))]
      public void Deal_ThrowsDeckOutOfCardsException_WhenOutOfCards() {
         // arrange
         var deck = new Deck();

         // act
         // assert
         deck.Deal(55);
      }

      [TestMethod]
      public void Burn_SingleCard_RemovesCardFromDeck() {
         // arrange
         var deck = new Deck();

         // act
         deck.Burn();

         // assert
         Assert.AreEqual(NUMBER_OF_CARDS_IN_FULL_DECK - 1, deck.NumCardsLeftInDeck);
      }

      [TestMethod]
      public void Burn_MultipleCards_RemovesCardFromDeck() {
         // arrange
         var deck = new Deck();
         var cardsToBurn = 5;

         // act
         deck.Burn(cardsToBurn);

         // assert
         Assert.AreEqual(NUMBER_OF_CARDS_IN_FULL_DECK - cardsToBurn, deck.NumCardsLeftInDeck);
      }

      [TestMethod]
      [ExpectedException(typeof(DeckOutOfCardsException))]
      public void Burn_ThrowsDeckOutOfCardsException_WhenOutOfCards() {
         // arrange
         var deck = new Deck();

         // act
         // assert
         deck.Burn(55);
      }
   }
}
