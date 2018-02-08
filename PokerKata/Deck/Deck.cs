using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerKata.Utils;

namespace PokerKata {
   public class Deck : IDeckService {
      private readonly List<Card> _deck;

      public int NumCardsLeftInDeck => _deck.Any() ? _deck.Count() : 0;

      public Deck(bool shuffle = true) {
         var allRanks = EnumHelpers.GetValues<Rank>();
         var allSuits = EnumHelpers.GetValues<Suit>();

         _deck = allRanks.SelectMany(sm => allSuits, (rank, suit) => new Card(rank, suit)).ToList();

         if (shuffle) {
            Shuffle();
         }
      }
      
      public IEnumerable<Card> Deal(int numberOfCards = 1) => RemoveCardsFromDeck(numberOfCards);
      public void Burn(int numberOfCards = 1) => RemoveCardsFromDeck(numberOfCards);

      private IEnumerable<Card> RemoveCardsFromDeck(int numberOfCards = 1) {
         if (this.NumCardsLeftInDeck - numberOfCards < 1) {
            throw new DeckOutOfCardsException();
         }

         var removedCards = _deck.Take(numberOfCards);
         _deck.RemoveAll(card => removedCards.Contains(card));

         return removedCards;
      }

      /// <summary>
      /// Shuffles the deck using the Fisher-Yates shuffle
      /// </summary>
      private void Shuffle() {
         var random = new Random();

         for (int i = 0; i < _deck.Count(); i++) {
            var index = i + random.Next(_deck.Count() - i);

            var temp = _deck[index];
            _deck[index] = _deck[i];
            _deck[i] = temp;
         }
      }
   }
}
