using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class FiveCardHandComparer : IHandComparer {
      private readonly IHandEvaluator _evaluator;

      public FiveCardHandComparer(IHandEvaluator evaluator) {
         _evaluator = evaluator;
      }

      public HandCompareResult Compare(Hand firstHand, Hand secondHand) {
         var firstRank = _evaluator.Evaluate(firstHand);
         var secondRank = _evaluator.Evaluate(secondHand);

         if (firstRank == secondRank) {
            return CompareSameRanks(firstRank, firstHand, secondHand);
         }
         else {
            return firstRank > secondRank
               ? HandCompareResult.FirstHandWins
               : HandCompareResult.SecondHandWins;
         }
      }

      private HandCompareResult CompareSameRanks(HandRank rank, Hand firstHand, Hand secondHand) {
         switch (rank) {
            case HandRank.RoyalFlush:
               return HandCompareResult.Split;
            case HandRank.StraightFlush:
            case HandRank.Flush:
            case HandRank.Straight:
               return new HighestRankComparer().Compare(firstHand, secondHand);
            case HandRank.FourOfAKind:
               return ComparePairedRanks(firstHand, secondHand);
         }

         // should not reach here (famous last words...)
         throw new Exception($"Unable to compare the two hands provided for rank ${rank}");
      }

      private HandCompareResult ComparePairedRanks(Hand firstHand, Hand secondHand) {
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
