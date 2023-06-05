using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var names = new List<string> {
                 "Tokyo", "New Delhi", "Bangkok", "London",
                            "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            Exercise2_1(names);
            Console.WriteLine("----");
            Exercise2_2(names);
            Console.WriteLine("----");
            Exercise2_3(names);
            Console.WriteLine("----");
            Exercise2_4(names);
        }

        private static void Exercise2_1(List<string> names) {
            Console.Write("都市名を入力してください > ");
            var name = Console.ReadLine();
            if (names.Contains(name)) {
                Console.WriteLine(names.FindIndex(s => s == name) + 1);
            }
            else {
                Console.WriteLine(-1);
            }
        }

        private static void Exercise2_2(List<string> names) {
            var count = names.Where(s => s.Contains('o')).Count();
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var cityNames = names.Where(s => s.Contains('o'));
            foreach (var cityName in cityNames) {
                Console.WriteLine(cityName);
            }
        }

        private static void Exercise2_4(List<string> names) {
            throw new NotImplementedException();
        }
    }
}
