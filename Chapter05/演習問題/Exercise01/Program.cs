using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            Console.Write("文字列１：");
            var str1 = Console.ReadLine();
            Console.Write("文字列２：");
            var str2 = Console.ReadLine();

            Console.WriteLine(String.Compare(str1, str2, true) == 0 ? "等しい" : "等しくない");

        }
    }
}
