using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public interface IDeckService {
      IEnumerable<Card> Deal(int numberOfCards);
      void Burn(int numberOfCards);
   }
}
