using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            #region Exercise01 Test
#if false
            var ym = new YearMonth(2023,12);
            var ymAdd = ym.AddOneMonth();
            bool c21 = ym.Is21Century;
            
            Console.WriteLine(ymAdd.ToString());
            Console.WriteLine(c21 + " " + ym.ToString());
#endif
            #endregion

            YearMonth[] yearMonths = {
                new YearMonth(1999, 1),
                new YearMonth(2000, 2),
                new YearMonth(2001, 3),
                new YearMonth(2002, 4),
                new YearMonth(2003, 5),
            };

            foreach (var ym in yearMonths) { //4-2-2
                Console.WriteLine(ym);
            }

            First21Century(yearMonths); //4-2-3

            //4-2-4
            Console.WriteLine(First21Century(yearMonths) ?? "21世紀のデータはありません");
        }

        public static string First21Century(YearMonth[] yearMonths) {
            foreach (var ym in yearMonths) { 
                if (ym.Is21Century) {
                    return ym.ToString();
                }
            }
            return null;
        }
    }
}
