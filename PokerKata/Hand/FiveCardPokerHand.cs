using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class FiveCardPokerHand : Hand {
      private const int REQUIRED_NUMBER_OF_CARDS = 5;

      public FiveCardPokerHand(IEnumerable<Card> cards)
         : base(cards) {

         if (cards.Count() != REQUIRED_NUMBER_OF_CARDS) {
            throw new InvalidFiveCardHandException(cards.Count());
         }
      }
   }
}
