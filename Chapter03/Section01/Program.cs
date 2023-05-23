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
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, }; //15, 3, 27, 40, 6, 2, 14, 75, 92, 8, 5, 
            //Judgement judge = IsEven; 
            //var count = numbers.Count(n => n % 5 == 0); //🔍拡張メソッド
            var sum = numbers.Sum(n => n % 2 == 0 ? n : 0);
            var sumAns = numbers.Where(n => n % 2 == 0).Sum();
            var avg = numbers.Average(n => n % 2 == 0 ? n : 0);
            var avgAns = numbers.Where(n => n % 2 == 0).Average();

            Console.WriteLine("合計：" + sum);
            Console.WriteLine("合計(模範解答)：" + sumAns);
            Console.WriteLine("平均：" + avg);
            Console.WriteLine("平均(模範解答)：" + avgAns);
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
