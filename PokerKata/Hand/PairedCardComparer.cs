using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class PairedCardComparer : IHandComparer {
      public HandCompareResult Compare(Hand firstHand, Hand secondHand) {
         var firstHandPairedCards = firstHand.GetPairedCards();
         var secondHandPairedCards = secondHand.GetPairedCards();

         var firstHandPairRank = firstHandPairedCards.First().Rank;
         var secondHandPairRank = secondHandPairedCards.First().Rank;

         var firstHandKickers = firstHand.Cards.Except(firstHandPairedCards).OrderByDescending(o => o.Rank);
         var secondHandKickers = secondHand.Cards.Except(secondHandPairedCards).OrderByDescending(o => o.Rank);

         if (firstHandPairRank != secondHandPairRank) {
            return firstHandPairRank > secondHandPairRank
               ? HandCompareResult.FirstHandWins
               : HandCompareResult.SecondHandWins;
         }

         for (int i = 0; i < firstHandKickers.Count(); i++) {
            var firstKicker = firstHandKickers.ElementAt(i).Rank;
            var secondKicker = secondHandKickers.ElementAt(i).Rank;

            if (firstKicker != secondKicker) {
               return firstKicker > secondKicker
                  ? HandCompareResult.FirstHandWins
                  : HandCompareResult.SecondHandWins;
            }
         }

         return HandCompareResult.Split;
      }
   }
}
