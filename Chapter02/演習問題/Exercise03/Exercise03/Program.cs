using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\Sales.csv");
            Console.WriteLine("** 売上集計 **");
            Console.WriteLine("1: 店舗別売り上げ");
            Console.WriteLine("2: 商品カテゴリ別売り上げ");
            Console.Write(">");
            int cursor = int.Parse(Console.ReadLine());

            IDictionary<String, int> amountPerX;
            do {
                if (cursor == 1) {
                    amountPerX = sales.GetPerStoreSales();
                    OutputAmountPerX(amountPerX);
                    break;
                }
                else if (cursor == 2) {
                    amountPerX = sales.GetPerCategorySales();
                    OutputAmountPerX(amountPerX);
                    break;
                }
                Console.WriteLine("正しい数ではありません。再入力してください。");
                Console.Write(">");
                cursor = int.Parse(Console.ReadLine());
            } while (true);
        }

        static void OutputAmountPerX(IDictionary<String, int> amountPerX) {
            foreach (var obj in amountPerX) {
                Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
            }
        }
    }
}
