using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class FiveCardHandComparer : IHandComparer {
      private readonly IHandEvaluator _evaluator;
      private readonly IHandComparerFactory _comparerFactory;

      public FiveCardHandComparer(IHandEvaluator evaluator, IHandComparerFactory comparerFactory) {
         _evaluator = evaluator;
         _comparerFactory = comparerFactory;
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
         return rank == HandRank.RoyalFlush
            ? HandCompareResult.Split
            : _comparerFactory.GetComparer(rank).Compare(firstHand, secondHand);
      }
   }
}
