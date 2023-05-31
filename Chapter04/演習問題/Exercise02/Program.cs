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
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            Console.WriteLine("\n- 4.2.2 ---");
            foreach (var ym in yearMonths) {
                Console.WriteLine(ym);
            }

            //Exercise2_2(ymCollection);
            
            Console.WriteLine(First21Century(yearMonths));
            Console.WriteLine();

            Console.WriteLine("\n- 4.2.4 ---");
            Console.WriteLine(First21Century(yearMonths).ToString() ?? "21世紀のデータはありません");

            Console.WriteLine("\n- 4.2.5 ---");
        }

        #region メイン関数中身
#if false
        // 4.2.1
        var ymCollection = new YearMonth[] {
                
            };

        // 4.2.2
        Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);
        Console.WriteLine("\n- 4.2.4 ---");

            // 4.2.4
            Exercise2_4(ymCollection);
        


            // 4.2.5
            Exercise2_5(ymCollection);
#endif
        #endregion

        public static YearMonth First21Century(YearMonth[] yearMonths) { //4-2-3
            foreach (var ym in yearMonths) { 
                if (ym.Is21Century) {
                    return ym;
                }
            }
            return null;
        }
    }
}
