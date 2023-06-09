﻿//#define NonArray
#define StringArray

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var novelists = new List<NovelistInfo> { };
            
#if NonArray
            //string[] novelistInputs = { "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886" };
            //novelistOptimization(novelistInputs, novelists, 0);
            string novelistInput = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886" ;
            foreach (var pair in novelistInput.Split(';')) {
                var array = pair.Split('=');
                Console.WriteLine("{0}：{1}", ToJapanese(array[0]), array[1]);
            }
#elif StringArray
            string[] novelistInputs = {
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886",
                "Novelist=夏目漱石;BestWork=坊ちゃん;Born=1867",
                "Novelist=太宰治;BestWork=人間失格;Born=1909",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
                "Novelist=宮沢賢治;BestWork=銀河鉄道の夜;Born=1896",
            };
            /*
            for (var i = 0; i < novelistInputs.Length; i++) {
                novelistOptimization(novelistInputs, novelists, i);
            }
            */
            foreach (var line in novelistInputs) {
                foreach (var pair in line.Split(';')) {
                    var array = pair.Split('=');
                    Console.WriteLine("{0}：{1}", ToJapanese(array[0]), array[1]);
                }
            }

#endif
            /*
            foreach (var novelist in novelists) { //出力
                novelist.ToString();
                Console.WriteLine();
            }
            */
            Console.WriteLine("実行時間 = {0}", sw.Elapsed.ToString(@"ss\.fffff"));
        }

        static string ToJapanese(string key) {
            switch (key) {
                case "Novelist": return "作家　：";
                case "BestWork": return "代表作：";
                case "Born": return "誕生年：";
            }
            throw new ArgumentException("正しい引数ではありません");
        }

        static void novelistOptimization(string[] novelistInput, List<NovelistInfo> novelists, int i) {
            //↓別のメソッドに分けたほうがよさそう
            string[] novelistInfoIndex = novelistInput[i].Split(';');

            for (int j = 0; j < novelistInfoIndex.Length; j++) { //要素以外の削除
                string ni = novelistInfoIndex[j]; //ni:novelist, index
                ni = ni.Remove(0, ni.IndexOf("=")+1);
                novelistInfoIndex[j] = ni;
            }
            //↑(ここまで)

            NovelistInfo novelistInfo = new NovelistInfo {
                Novelist = novelistInfoIndex[0],
                BestWork = novelistInfoIndex[1],
                Born = int.Parse(novelistInfoIndex[2])
            };

            novelists.Add(novelistInfo);
        }
    }
}
