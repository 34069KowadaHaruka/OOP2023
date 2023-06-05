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
        #region 自回答
        #if false
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
            var query = names.Where(s => s.FirstOrDefault() == 'B')
                            .Select(s => s.Length);
            foreach (var n in query) {
                Console.Write("{0}, ", n);
            }
        }
#endif
        #endregion

        private static void Exercise2_1(List<string> names) {
            Console.WriteLine("都市名を入力。空行で終了");
            do {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                    break;

                var index = names.FindIndex(s => s.Equals(line));
                Console.WriteLine(index);
            } while (true);
        }

        private static void Exercise2_2(List<string> names) {
            //var count = names.Where(s => s.Contains('o')).Count();
            var count = names.Count(s => s.Contains('o'));
            Console.WriteLine(count);
        }

        private static void Exercise2_3(List<string> names) {
            var selected = names.Where(s => s.Contains('o'))
                                .ToArray();
            foreach (var name in selected)
                Console.WriteLine(name);
        }

        private static void Exercise2_4(List<string> names) {
            var selected = names.Where(s => s.StartsWith("B"))
                                .Select(s => new { s, s.Length });

            foreach (var item in selected) {
                Console.WriteLine("{0},{1}", item.s, item.Length);
            }
        }
    }
}
