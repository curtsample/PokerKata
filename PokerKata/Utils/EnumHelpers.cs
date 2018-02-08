using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerKata.Utils {
   public static class EnumHelpers {
      public static IEnumerable<T> GetValues<T>() => Enum.GetValues(typeof(T)).Cast<T>();
   }
}
