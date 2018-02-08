using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class DeckOutOfCardsException : Exception {
      public DeckOutOfCardsException()
         : base(string.Empty) { }

      public DeckOutOfCardsException(string message)
         : base(message) { }
   }
}
