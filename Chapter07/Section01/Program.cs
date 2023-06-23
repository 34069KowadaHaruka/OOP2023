using Microsoft.VisualBasic;
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
            var PrefCapitalDict = new Dictionary<string, CityInfo>();

            Console.WriteLine("県庁所在地の登録");

            while(true){

                Console.Write("県名：");
                var prefecture = Console.ReadLine();
                CityInfo cityInfo;

                if (ci.Compare(prefecture, "999", System.Globalization.CompareOptions.IgnoreWidth) == 0) {
                    break;
                }
                else if (PrefCapitalDict.ContainsKey(prefecture)) {

                    Console.WriteLine("その件の県庁所在地は既に登録されています。上書きしますか？ ( はい / いいえ )");
                    Console.WriteLine("登録されている{0}の県庁所在地：{1}({2}人)",
                                    prefecture, PrefCapitalDict[prefecture].City, PrefCapitalDict[prefecture].Population);

                    if (Console.ReadLine() == "はい") {
                        cityInfo = InputCity();
                    }
                    else {
                        continue;
                    }

                }
                else {
                    cityInfo = InputCity();
                }
                
                Console.WriteLine();

                PrefCapitalDict[prefecture] = cityInfo;
            }

            Console.WriteLine("1：一覧表示　2：県名指定");
            Console.Write(">");
            var num = Strings.StrConv(Console.ReadLine(), VbStrConv.Narrow, 0);
            //intになってから実行
            switch (num) {

                case "1":
                    try {
                        foreach (var pref in PrefCapitalDict) {
                            if (PrefCapitalDict.Keys == null) {
                                Console.WriteLine("コレクションにはデータがありません");
                                break;
                            }
                            Console.WriteLine("{0}({1}, 人口：{2}人)", pref.Key, pref.Value.City, pref.Value.Population);
                        }
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine("コレクションにはデータがありません");
                    }
                    break;

                case "2":
                    try {
                        Console.Write("県名を入力：");
                        var getCapitalPref = Console.ReadLine();
                        Console.WriteLine("{0} (人口：{1}人)です", PrefCapitalDict[getCapitalPref].City,
                                            PrefCapitalDict[getCapitalPref].Population);
                    }
                    catch (KeyNotFoundException) {
                        Console.WriteLine("コレクションにそのデータはありません");
                    }
                    break;

            }

#endif
            #endregion

        }

        public static CityInfo InputCity() {
            string city;
            int population;

            Console.Write("所在地：");
            city = Console.ReadLine();
            Console.Write("所在地の人口：");
            population = int.Parse(Strings.StrConv(Console.ReadLine(), VbStrConv.Narrow, 0));

            var cityInfo = new CityInfo {
                City = city, 
                Population = population, 
            };

            return cityInfo;
        }
    }

    class CityInfo {
        public string City { get; set; }
        public int Population { get; set; }
    }
}
