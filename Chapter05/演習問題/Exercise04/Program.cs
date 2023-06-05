using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            string novelistInput = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            string[] novelistInfoIndex = novelistInput.Split(';');

            for (int i = 0; i < novelistInfoIndex.Length; i++) {
                string ni = novelistInfoIndex[i]; //ni:novelist, index
                var index = ni.IndexOf("=");
                ni = ni.Remove(0, index+1);
                novelistInfoIndex[i] = ni;
            }

            NovelistInfo novelistInfo = new NovelistInfo {
                Novelist = novelistInfoIndex[0],
                BestWork = novelistInfoIndex[1],
                Born = int.Parse(novelistInfoIndex[2])
            };
            Console.WriteLine("作家　：" + novelistInfo.Novelist);
            Console.WriteLine("代表作：" + novelistInfo.BestWork);
            Console.WriteLine("誕生年：" + novelistInfo.Born);
        }
    }
}
