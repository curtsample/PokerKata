using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public interface IHandComparer {
      HandCompareResult Compare(Hand firstHand, Hand secondHand);
   }
}
