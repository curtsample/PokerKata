using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class HandComparerFactory : IHandComparerFactory {
      public IHandComparer GetComparer(HandRank rank) {
         if (_comparerMap.ContainsKey(rank)) {
            return Activator.CreateInstance(_comparerMap[rank]) as IHandComparer;
         }

         throw new Exception($"Could not find a valid comparer for rank {rank}");
      }

      private static readonly IDictionary<HandRank, Type> _comparerMap = new Dictionary<HandRank, Type> {
         { HandRank.StraightFlush, typeof(HighestRankComparer) },
         { HandRank.Flush, typeof(HighestRankComparer) },
         { HandRank.Straight, typeof(HighestRankComparer) },
         { HandRank.FourOfAKind, typeof(PairedCardComparer) },
         { HandRank.ThreeOfAKind, typeof(PairedCardComparer) },
         { HandRank.Pair, typeof(PairedCardComparer) }
      };
   }
}
