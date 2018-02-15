using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   public class HandCompareTestData {
      public Hand First { get; private set; }
      public Hand Second { get; private set; }
      public HandCompareResult ExpectedResult { get; private set; }

      public HandCompareTestData(Hand first, Hand second, HandCompareResult expectedResult) {
         First = first;
         Second = second;
         ExpectedResult = expectedResult;
      }

      public static HandCompareTestData[] GetTestData(Hand winningHand, Hand losingHand) {
         return new[] {
            new HandCompareTestData(winningHand, losingHand, HandCompareResult.FirstHandWins),
            new HandCompareTestData(losingHand, winningHand, HandCompareResult.SecondHandWins),
            new HandCompareTestData(winningHand, winningHand, HandCompareResult.Split)
         };
      }
   }
}
