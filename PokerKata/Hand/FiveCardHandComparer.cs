﻿using System;
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
         throw new NotImplementedException();
      }
   }
}