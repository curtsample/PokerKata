using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class HandComparerFactory : IHandComparerFactory {
      public IHandComparer GetComparer(HandRank rank) {
         throw new NotImplementedException();
      }
   }
}
