using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section02 {
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
            var prefCapitalDict = new Dictionary<string, List<CityInfo>>();

            Console.WriteLine("都市の登録");

            while (true) {

                Console.Write("県名：");
                var prefecture = Console.ReadLine();
                CityInfo cityInfo;

                if (ci.Compare(prefecture, "999", System.Globalization.CompareOptions.IgnoreWidth) == 0) {
                    break;
                }
                else if (prefCapitalDict.ContainsKey(prefecture)) {

                    Console.WriteLine("その県の都市は既に登録されています。追加しますか？ ( はい / いいえ )");
                    Console.WriteLine();
                    Console.WriteLine("登録されている{0}の都市", prefecture);
                    foreach (var city in prefCapitalDict[prefecture]) {
                        Console.WriteLine("・{0}({1}人) ", city.City, city.Population);
                    }
                    
                    if (Console.ReadLine() == "はい") {
                        cityInfo = InputCity();
                    }
                    else {
                        continue;
                    }

                }
                else {
                    prefCapitalDict[prefecture] = new List<CityInfo>();
                    cityInfo = InputCity();
                }

                Console.WriteLine();

                prefCapitalDict[prefecture].Add(cityInfo);
            }

            Console.WriteLine("1：一覧表示　2：県名指定");
            Console.Write(">");

            //↓ null→0に
            int.TryParse(Strings.StrConv(Console.ReadLine(), VbStrConv.Narrow, 0), out var num);
            switch (num) {

                case 1:
                    try { //一つもデータを登録しなかったとき、エラーにならず、KeyをStringにしてみても、nullともEmptyとも判定されない。何も出ずに終了となるのが嫌
                        foreach (var pref in prefCapitalDict) {
                            foreach (var city in pref.Value) {
                                Console.WriteLine("{0}({1}, 人口：{2}人)", pref.Key, city.City, city.Population);
                            }
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
                        foreach (var city in prefCapitalDict[getCapitalPref]) {
                            Console.Write("{0}({1}人) ", city.City, city.Population);
                        }
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

            Console.Write("都市名：");
            city = Console.ReadLine();
            Console.Write("都市の人口：");
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

