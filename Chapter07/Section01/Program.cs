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
            var ci = System.Globalization.CultureInfo.CurrentCulture.CompareInfo;
            var PrefCapitalDict = new Dictionary<string, string>();

            Console.WriteLine("県庁所在地の登録");

            while(true){

                Console.Write("県名：");
                var prefecture = Console.ReadLine();

                if (ci.Compare(prefecture, "999", System.Globalization.CompareOptions.IgnoreWidth) == 0) {
                    break;
                }
                else if (PrefCapitalDict.ContainsKey(prefecture)) {

                    Console.WriteLine("その件の県庁所在地は既に登録されています。上書きしますか？ ( はい / いいえ )");
                    Console.WriteLine("登録されている{0}の県庁所在地：{1}", prefecture, PrefCapitalDict[prefecture]);

                    if (Console.ReadLine() == "はい") {
                        Console.Write("所在地：");
                    }
                    else {
                        continue;
                    }

                }
                else { 
                    Console.Write("所在地：");
                }
                var capital = Console.ReadLine();
                Console.WriteLine();

                PrefCapitalDict[prefecture] = capital;
            }

            Console.WriteLine("1：一覧表示　2：県名指定");
            Console.Write(">");
            int.TryParse(Console.ReadLine(), out var num); //全角数字を変換しないのが気に入らない

            switch (num) {

                case 1:
                    try {
                        foreach (var pref in PrefCapitalDict) {
                            Console.WriteLine("{0}({1})", pref.Key, pref.Value);
                        }
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine("コレクションにはデータがありません");
                    }
                    break;

                case 2:
                    try {
                        Console.Write("県名を入力：");
                        var getCapitalPref = Console.ReadLine();
                        Console.WriteLine(PrefCapitalDict[getCapitalPref] + "です");
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine("コレクションにそのデータはありません");
                    }
                    break;

            }

            
            
#endif
            #endregion

        }
    }

    class CityInfo {
        string City { get; set; }
        string Population { get; set; }
    }
}
