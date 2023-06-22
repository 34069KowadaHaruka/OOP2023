using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            #region flowerDict
#if false
            var flowerDict = new Dictionary<string, int> {
                ["sunflower"] = 400,
                ["pansy"] = 300,
                ["tulip"] = 350,
                ["rose"] = 500,
                ["dahlia"] = 450,
            };

            //flowerDict.Add("morning glory", 250);
            flowerDict["morning glory"] = 250;

            Console.WriteLine("ひまわりは{0}円です", flowerDict["sunflower"]);
            Console.WriteLine("チューリップは{0}円です", flowerDict["tulip"]);
            Console.WriteLine("朝顔は{0}円です", flowerDict["morning glory"]);

            //foreach (var flower in flowerDict) {
            //    Console.WriteLine(flower.Key + "は{0}円です", flower.Value);
            //}
#endif
            #endregion

            #region PrefCapitalDict
#if true
            var PrefCapitalDict = new Dictionary<string, string>();

            Console.WriteLine("県庁所在地の登録");

            while(true){

                Console.Write("県名：");
                var prefecture = Console.ReadLine();

                if (prefecture == "999") {

                    break;

                }
                else if (PrefCapitalDict.ContainsKey(prefecture)) {

                    Console.WriteLine("その件の県庁所在地は既に登録されています。上書きしますか？( はい / いいえ )");
                    Console.WriteLine("登録されている{0}の県庁所在地：{1}", prefecture, PrefCapitalDict[prefecture]);

                    if (Console.ReadLine() == "はい") {
                        Console.Write("所在地：");
                    }

                }
                else { 
                    Console.Write("所在地：");
                }
                
                var capital = Console.ReadLine();

                PrefCapitalDict[prefecture] = capital;
            }

            Console.Write("県名を入力：");
            
            try {
                var getCapitalPref = Console.ReadLine();
                Console.WriteLine(PrefCapitalDict[getCapitalPref] + "です");
            }
            catch (KeyNotFoundException) {
                Console.WriteLine("コレクションにそのデータはありません");
            }
            
#endif
            #endregion

        }
    }
}
