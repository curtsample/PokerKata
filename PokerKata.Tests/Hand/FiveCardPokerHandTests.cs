﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PokerKata.Tests {
   [TestClass]
   public class FiveCardPokerHandTests {
      [TestMethod]
      public void HasRoyalFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithRoyalFlush, true),
            new TestData(HandHelpers.HandWithStraightFlush, false),
            new TestData(HandHelpers.HandWithFlush, false),
            new TestData(HandHelpers.HandWithStraight, false),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasRoyalFlush());
      }

      [TestMethod]
      public void HasStraightFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithStraightFlush, true),
            new TestData(HandHelpers.HandWithFlush, false),
            new TestData(HandHelpers.HandWithStraight, false),
            new TestData(HandHelpers.HandWithNothing, false),
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasStraightFlush());
      }

      [TestMethod]
      public void HasFourOfAKind_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithFourOfAKind, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasFourOfAKind());
      }

      [TestMethod]
      public void HasFlush_Success() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithFlush, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasFlush());
      }

      [TestMethod]
      public void HasStraight_Success() {
         // arrange


         var testData = new[] {
            new TestData(HandHelpers.HandWithStraight, true),
            new TestData(HandHelpers.HandWithAceLowStraight, true),
            new TestData(HandHelpers.HandWithAceLowNotQuiteStraight, false),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasStraight());
      }      

      [TestMethod]
      public void HasTwoPair_WithTwoPair_ReturnsTrue() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithTwoPair, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasTwoPair());
      }

      [TestMethod]
      public void HasThreeOfAKind_WithThreeOfAKind_ReturnsTrue() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithThreeOfAKind, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasThreeOfAKind());
      }

      [TestMethod]
      public void HasPair_WithPair_ReturnsTrue() {
         // arrange
         var testData = new[] {
            new TestData(HandHelpers.HandWithPair, true),
            new TestData(HandHelpers.HandWithNothing, false)
         };

         // act & assert
         AssertTestData(testData, hand => hand.HasPair());
      }

      private void AssertTestData(TestData[] testData, Func<FiveCardPokerHand, bool> action) {
         foreach(var test in testData) {
            Assert.AreEqual(test.ExpectedResult, action.Invoke(test.Hand));
         }
      }

      private class TestData {
         public FiveCardPokerHand Hand { get; private set; }
         public bool ExpectedResult { get; private set; }

         public TestData(FiveCardPokerHand hand, bool expectedResult) {
            Hand = hand;
            ExpectedResult = expectedResult;
         }
      }
   }
}