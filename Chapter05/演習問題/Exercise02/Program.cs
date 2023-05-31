using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Console.Write("文字列：");
            var str = Console.ReadLine();
            int num;

            if (int.TryParse(str, out num)) {
                Console.WriteLine("{0:0.0}", num);
            }
            else {
                Console.WriteLine("数値文字列ではありません");
            }
        }
    }
}
