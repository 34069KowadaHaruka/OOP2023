using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter(@"data\Sales.csv");
            Console.WriteLine("**売上集計**");
            Console.WriteLine("1:店舗別売上");
            Console.WriteLine("2:商品カテゴリ別売上");
            Console.Write("＞ ");
            int cursor = int.Parse(Console.ReadLine());
            do {
                if (cursor == 1) {
                    var amountPerStore = sales.GetPerStoreSales();
                    foreach (var obj in amountPerStore) {
                        Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                    }
                    break;
                }
                else if (cursor == 2) {
                    var amountPerCategory = sales.GetPerCategorySales();
                    foreach (var obj in amountPerCategory) {
                        Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
                    }
                    break;
                }
                Console.WriteLine("正しい数ではありません。再入力してください。");
                Console.Write("＞ ");
                cursor = int.Parse(Console.ReadLine());
            } while (cursor != 1 && cursor != 2);
            
        }
    }
}
