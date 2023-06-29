using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {

            var abbrs = new Abbreviations();

            //Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");

            //インデクサの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs[name];
                if (fullname == null) {
                    Console.WriteLine("{0}は見つかりません", name);
                }
                else {
                    Console.WriteLine("{0}={1}", name, fullname);
                }
            }
            Console.WriteLine();

            //ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            Console.WriteLine("{0}={1}", japanese, abbreviation);
            Console.WriteLine();

            //FindAllメソッドの利用例
            foreach (var item in abbrs.FindAll("国際")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            Console.WriteLine();

            Console.WriteLine("---Exercise02---");

            Console.WriteLine(abbrs.CountWords());
            Console.WriteLine();
            Console.WriteLine(abbrs.Remove("FIFA"));
            /*
            foreach (var item in abbrs.FindAll("")) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }
            */
            Console.WriteLine();
            foreach (var item in abbrs.OnlyThreeAbbr()) {
                Console.WriteLine("{0}={1}", item.Key, item.Value);
            }

        }
    }
}
