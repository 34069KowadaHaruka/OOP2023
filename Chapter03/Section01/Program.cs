using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Count(5));
        }

        public static int Count(int num) {
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 5, 10, 4, };
            int count = 0;
            foreach (int n in numbers) {
                if (n == num) {
                    count++;
                }
            }
            return count;
        }
    }
}
