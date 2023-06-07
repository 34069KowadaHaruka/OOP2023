using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            var skip = numbers.Length-2;
            foreach (var item in numbers.Skip(skip)) {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        private static void Exercise1_3(int[] numbers) {
            var strNumbers = numbers.Select(n => n.ToString());
            foreach (var item in strNumbers) {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        private static void Exercise1_4(int[] numbers) {
            var orderdByNumbers = numbers.OrderBy(n => n).Take(3).ToArray();
            foreach (var n in orderdByNumbers) {
                Console.Write(n + ", ");
            }
            Console.WriteLine();
        }

        private static void Exercise1_5(int[] numbers) {
            var over10 = numbers.Distinct().Count(n => n > 10);
            Console.WriteLine(over10);
        }
    }
}
