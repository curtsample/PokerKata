using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class InvalidFiveCardHandException : Exception {
      public int NumberOfCards { get; private set; }

      public InvalidFiveCardHandException(int numberOfCards)
         : base($"Invalid five card hand -> ${numberOfCards} provided") { }
   }
}
