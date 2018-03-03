using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibarySyte.ConstSyte.ConstOlimpikz
{
   internal class ConstParse
   {
        /// <summary>
        /// Собственно наши матчи
        /// </summary>
       internal static string ViewMath = "//div[contains(@class, 'match_live-sport sport')]";
        /// <summary>
        /// Запрос на поиск Вида игры Футбол и т.д.
        /// </summary>
        internal static string ViewGemes = "div[contains(@class, 'sport-title')]";
   }
}
