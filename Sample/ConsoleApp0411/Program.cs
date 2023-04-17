using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0411 {
    class Program {
        static void Main(string[] args) {
           
            Console.Write("金額:");
            int amount = int.Parse(Console.ReadLine());
            Console.Write("支払:");
            int payment = int.Parse(Console.ReadLine());
            int change = payment - amount;
            Console.WriteLine("お釣:" + change + "円");

            string[] MoneyStrings = {"一万円札", "五千円札", "二千円札", "　千円札", "五百円玉", 
                                    "　百円玉", "五十円玉", "　十円玉", "　五円玉", "　一円玉",};
            int[] MoneyKinds = {10000,5000,2000,1000,500,100,50,10,5,1,}; //MoneyIntegerのほうが良い(Stringsがあるので)
            //枚数重ねとく配列は不要
            
            for (int i = 0; i < MoneyKinds.Length; i++)
            {
                Console.WriteLine(MoneyStrings[i] + ":{0}枚", change / MoneyKinds[i]);
                change %= MoneyKinds[i];
            }
            Console.WriteLine();

            /* 模範解答 配列なし
            Console.WriteLine("一万円札: {0}枚" + change / 10000);
            change %= 10000;
            …
            */

            int change2 = payment - amount;
            //金種枚数出力(記号)
            for (int i = 0; i < MoneyKinds.Length; i++)
            {
                Console.Write(MoneyStrings[i] + ":");
                astOut(change2 / MoneyKinds[i]);
                change2 %= MoneyKinds[i];
            }
        }

        private static void astOut(int quantity) {
            for (int i = 0; i < quantity; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}