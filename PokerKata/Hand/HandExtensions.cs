using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata {
   public static class HandExtensions {
      private const int CARDS_IN_FIVE_CARD_HAND = 5;

      public static bool HasRoyalFlush(this Hand hand) {
         var highestRank = hand.Cards.Max(m => m.Rank);

         return highestRank == Rank.Ace
            && hand.HasStraightFlush();
      }

      public static bool HasStraightFlush(this Hand hand) =>
         hand.HasFlush() && hand.HasStraight();      

      public static bool HasFourOfAKind(this Hand hand) =>
         hand.GroupedByRank()
            .Where(w => w.Count == 4)
            .Any();

      public static bool HasFullHouse(this Hand hand) =>
         hand.HasThreeOfAKind() && hand.HasPair();

      public static bool HasFlush(this Hand hand) =>
         hand.GroupedBySuit()
            .Where(w => w.Count == 5)
            .Any();

      public static bool HasStraight(this Hand hand) {
         var orderedHand = hand.Cards.OrderBy(o => o.Rank);

         var highestRank = orderedHand.Max(m => m.Rank);
         var lowestRank = orderedHand.Min(m => m.Rank);         

         if (orderedHand.Select(s => (int)s.Rank).SequenceEqual(StraightRanks(lowestRank))) {
            return true;
         }

         // the above won't take an ace low straight into account
         // A - 2 - 3 - 4 -5
         // so lets check
         if (highestRank == Rank.Ace && lowestRank == Rank.Two) {
            return orderedHand
               .Take(CARDS_IN_FIVE_CARD_HAND - 1) // discard the ace, basically
               .Select(s => (int)s.Rank)
               .SequenceEqual(AceLowStraightRanks);
         }

         return false; // no straight found
      }

      public static bool HasTwoPair(this Hand hand) =>
         hand.GroupedByRank()
            .Where(w => w.Count == 2)
            .Count() == 2;      

      public static bool HasThreeOfAKind(this Hand hand) =>
         hand.GroupedByRank()
            .Where(w => w.Count == 3)
            .Any();      

      public static bool HasPair(this Hand hand) =>
         hand.GroupedByRank()            
            .Where(w => w.Count == 2)
            .Any();

      #region Helpers

      private static IEnumerable<RankGrouped> GroupedByRank(this Hand hand) =>
         hand.Cards
            .GroupBy(g => g.Rank)
            .Select(s => new RankGrouped { Rank = s.Key, Count = s.Count() });

      private static IEnumerable<SuitGrouped> GroupedBySuit(this Hand hand) =>
         hand.Cards
            .GroupBy(g => g.Suit)
            .Select(s => new SuitGrouped { Suit = s.Key, Count = s.Count() });      

      private static IEnumerable<int> StraightRanks(Rank lowestRank) =>
         Enumerable.Range((int)lowestRank, CARDS_IN_FIVE_CARD_HAND);

      private static IEnumerable<int> AceLowStraightRanks =>
         Enumerable.Range((int)Rank.Two, CARDS_IN_FIVE_CARD_HAND - 1);

      private class RankGrouped {
         public Rank Rank { get; set; }
         public int Count { get; set; }
      }

      private class SuitGrouped {
         public Suit Suit { get; set; }
         public int Count { get; set; }
      }

      #endregion
   }
}
