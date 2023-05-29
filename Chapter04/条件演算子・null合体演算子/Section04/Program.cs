using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section04 {
    class Program {
        static void Main(string[] args) {
            var list = new List<int> {10,20,30,4, };
            var key = 40;

            var num = list.Contains(key) ? 1 : 0;
            Console.WriteLine(num);
        }
    }
}
