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

            var ymCollection = new YearMonth[] {
                new YearMonth(1980, 1),
                new YearMonth(1990, 4),
                new YearMonth(2000, 7),
                new YearMonth(2010, 9),
                new YearMonth(2020, 12),
            };

            Console.WriteLine("\n- 4.2.2 ---");
            Exercise2_2(ymCollection);

            //Console.WriteLine("\n- 4.2.3 ---");
            //Console.WriteLine(First21Century(ymCollection));

            Console.WriteLine("\n- 4.2.4 ---");
            Exercise2_4(ymCollection);
            
            Console.WriteLine("\n- 4.2.5 ---");
            Exercise2_5(ymCollection);
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }

        public static YearMonth First21Century(YearMonth[] ymCollection) { //4-2-3
            foreach (var ym in ymCollection) { 
                if (ym.Is21Century) {
                    return ym;
                }
            }
            return null;
        }

        public static void Exercise2_4(YearMonth[] ymCollection) {
            Console.WriteLine(First21Century(ymCollection)?.ToString() ?? "21世紀のデータはありません");
        }
        
        private static void Exercise2_5(YearMonth[] ymCollection) {
            var array = ymCollection.Select(ym => ym.AddOneMonth()).ToArray();
            Exercise2_2(array);
        }

        
    }
}
