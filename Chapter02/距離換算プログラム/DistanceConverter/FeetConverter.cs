using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter { //staticメソッドしかない→staticクラスにしておけばインスタンスを作ろうとしたときにエラーが出るので、他開発者に向けたプログラムとして良い

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / 0.3408;
        }

        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * 0.3048;
        }

    }
}
