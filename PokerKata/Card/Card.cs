using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class Card {
      public Rank Rank { get; set; }
      public Suit Suit { get; set; }

      public Card(Rank rank, Suit suit) {
         this.Rank = rank;
         this.Suit = suit;
      }

      public override string ToString() => string.Format("{0} of {1}", this.Rank, this.Suit);
   }
}
