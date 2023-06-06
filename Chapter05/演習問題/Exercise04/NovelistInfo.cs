using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04 {
    class NovelistInfo {
        //作家
        public string Novelist { get; set; }
        //代表作
        public string BestWork { get; set; }
        //誕生年
        public int Born { get; set; }

        public override string ToString() {
            string[] novelistPropaty = { "作家　：", "代表作：", "誕生年：", };
            Console.WriteLine(novelistPropaty[0]+ Novelist);
            Console.WriteLine(novelistPropaty[1]+ BestWork);
            Console.WriteLine(novelistPropaty[2]+ Born);
            return base.ToString();
        }
    }
}
