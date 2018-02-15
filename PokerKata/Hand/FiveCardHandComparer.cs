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
               return new PairedCardComparer().Compare(firstHand, secondHand);
         }

         // should not reach here (famous last words...)
         throw new Exception($"Unable to compare the two hands provided for rank ${rank}");
      }
   }
}
