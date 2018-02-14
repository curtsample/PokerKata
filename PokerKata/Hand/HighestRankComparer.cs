using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class HighestRankComparer : IHandComparer {
      public HandCompareResult Compare(Hand firstHand, Hand secondHand) {
         if (firstHand.Cards.OrderBy(o => o.Rank)
            .SequenceEqual(secondHand.Cards.OrderBy(o => o.Rank))) {

            return HandCompareResult.Split;
         }

         return firstHand.Cards.Max(card => card.Rank) > secondHand.Cards.Max(card => card.Rank)
            ? HandCompareResult.FirstHandWins
            : HandCompareResult.SecondHandWins;
      }
   }
}
