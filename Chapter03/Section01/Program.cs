using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {

        //public delegate bool Judgement(int value); //デリゲートの宣言
        //Judgement型のdelegate みたいなイメージかも

        static void Main(string[] args) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, };
            //Judgement judge = IsEven; 

            int count = numbers.Count(n => n % 2 == 0); //🔍拡張メソッド
            Console.WriteLine(count);
        }

        //public static bool IsEven(int n) {
        //    return n % 2 != 0;
        //}
        #region Countメソッド
        #if (false)
        public static int Count(int[] numbers, Predicate<int> judge) {
            int count = 0;
            foreach (var n in numbers) {
                if (judge(n) == true) {
                    count++;
                }
            }
            return count;
        }
        #endif
        #endregion
    }
}
