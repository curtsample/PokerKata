using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class InvalidEvaluationHandException : Exception {
      public int NumberOfCards { get; private set; }

      public InvalidEvaluationHandException(int numberOfCards)
         : base($"Can't evaluate hand with ${numberOfCards} cards") { }
   }
}
