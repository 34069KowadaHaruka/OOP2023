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
            return base.ToString();
        }
    }
}
