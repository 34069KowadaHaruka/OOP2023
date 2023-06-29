using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";
            Exercise1_1(text);
            Console.WriteLine();
            Exercise1_2(text);
        }

        private static void Exercise1_1(string text) {
            var dict = new Dictionary<char, int>();
            foreach (var ch in text) {
                var uc = char.ToUpper(ch);
                if ('A' <= uc && uc <= 'Z') {
                    if (dict.ContainsKey(uc)) {
                        dict[uc]++;
                    }
                    else {
                        dict.Add(uc, 1);
                    }
                }
            }

            foreach (var item in dict.OrderBy(c => c.Key)) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }

        private static void Exercise1_2(string text) {
            var sdict = new SortedDictionary<char, int>();
            foreach (var ch in text) {
                var uc = char.ToUpper(ch);
                if ('A' <= uc && uc <= 'Z') {
                    if (sdict.ContainsKey(uc)) {
                        sdict[uc]++;
                    }
                    else {
                        sdict.Add(uc, 1);
                    }
                }
            }
            foreach (var item in sdict) {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
            Console.WriteLine();
        }
    }
}
