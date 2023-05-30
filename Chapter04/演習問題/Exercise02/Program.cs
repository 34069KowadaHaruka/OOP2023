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

            foreach (var ym in yearMonths) {
                Console.WriteLine(ym);
            }
        }
    }
}
