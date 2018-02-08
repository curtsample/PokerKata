using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Tests {
   public static class HandHelpers {
      public static FiveCardPokerHand HandWithRoyalFlush => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.King, Suit.Clubs),
            new Card(Rank.Queen, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.Ten, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithStraightFlush => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Five, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Eight, Suit.Clubs),
            new Card(Rank.Nine, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithFourOfAKind => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Ace, Suit.Clubs),
            new Card(Rank.Eight, Suit.Hearts)
         });

      public static FiveCardPokerHand HandWithFlush => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Two, Suit.Clubs),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.King, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithAceLowStraight => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Four, Suit.Clubs),
            new Card(Rank.Three, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Five, Suit.Diamonds),
            new Card(Rank.Two, Suit.Hearts)
         });

      // "edge" case I encountered, if we have an Ace + four sequential cards
      // that didn't equal an ace low straight
      // ie A - 5 - 6 - 7 - 8
      // was being flagged as a straight in a previous implementation
      public static FiveCardPokerHand HandWithAceLowNotQuiteStraight => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Five, Suit.Diamonds),
            new Card(Rank.Six, Suit.Diamonds),
            new Card(Rank.Seven, Suit.Clubs),
            new Card(Rank.Eight, Suit.Hearts)
         });

      public static FiveCardPokerHand HandWithStraight => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Nine, Suit.Spades),
            new Card(Rank.Seven, Suit.Diamonds),
            new Card(Rank.Five, Suit.Spades),
            new Card(Rank.Six, Suit.Clubs),
            new Card(Rank.Eight, Suit.Hearts)
         });

      public static FiveCardPokerHand HandWithTwoPair => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Jack, Suit.Clubs),
            new Card(Rank.Three, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithThreeOfAKind => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Ace, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithPair => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Ace, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });

      public static FiveCardPokerHand HandWithNothing => new FiveCardPokerHand(new List<Card> {
            new Card(Rank.Two, Suit.Spades),
            new Card(Rank.Ace, Suit.Diamonds),
            new Card(Rank.Jack, Suit.Hearts),
            new Card(Rank.Eight, Suit.Hearts),
            new Card(Rank.Three, Suit.Clubs)
         });
   }
}
