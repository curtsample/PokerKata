using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class FiveCardPokerHand : Hand {
      public FiveCardPokerHand(IEnumerable<Card> cards)
         : base(cards) {         
      }
   }
}
