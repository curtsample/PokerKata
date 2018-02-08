using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public class FiveCardHandEvaluator : IHandEvaluator {
      public HandRank Evaluate(Hand hand) {
         if (hand.HasRoyalFlush()) {
            return HandRank.RoyalFlush;
         }
         else if (hand.HasStraightFlush()) {
            return HandRank.StraightFlush;
         }
         else if (hand.HasFourOfAKind()) {
            return HandRank.FourOfAKind;
         }
         else if (hand.HasFullHouse()) {
            return HandRank.FullHouse;
         }
         else if (hand.HasFlush()) {
            return HandRank.Flush;
         }
         else if (hand.HasStraight()) {
            return HandRank.Straight;
         }
         else if (hand.HasThreeOfAKind()) {
            return HandRank.ThreeOfAKind;
         }
         else if (hand.HasTwoPair()) {
            return HandRank.TwoPair;         
         }
         else if (hand.HasPair()) {
            return HandRank.Pair;
         }

         return HandRank.HighCard;
      }
   }
}
