using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
#if true
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
#else
            var numbers = new List<int> { 12, 87, 94, 14, 53, 20, 4, 35, 76, 91, 31, 17, 4 };
#endif

            // 3.1.1
            Exercise1_1(numbers);
            Console.WriteLine("-----");

            // 3.1.2
            Exercise1_2(numbers);
            Console.WriteLine("-----");

            // 3.1.3
            Exercise1_3(numbers);
            Console.WriteLine("-----");

            // 3.1.4
            Exercise1_4(numbers);
        }

        private static void Exercise1_1(List<int> numbers) {
            var exist = numbers.Exists(n => n % 8 == 0 || n % 9 == 0);
            if (exist) {
                Console.WriteLine("存在しています");

            }else {
                Console.WriteLine("存在していません");
            }
        }

        private static void Exercise1_2(List<int> numbers) {
            numbers.ForEach(n => Console.WriteLine(((double)n / 2)));
        }

        private static void Exercise1_3(List<int> numbers) {
            IEnumerable<int> nums50 = numbers.Where(i => i >= 50);
            foreach (int i in nums50) {
                Console.WriteLine(i);
            }
        }

        private static void Exercise1_4(List<int> numbers) {
            var nums2 = numbers.Select(i => i * 2);
            foreach (var i in nums2) {
                Console.WriteLine(i);
            }
        }
    }
}
