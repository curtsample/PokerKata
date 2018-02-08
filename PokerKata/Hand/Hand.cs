using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class Hand {
      public IEnumerable<Card> Cards { get; private set; }      

      public Hand(IEnumerable<Card> cards) {
         Cards = cards;
      }
   }
}
