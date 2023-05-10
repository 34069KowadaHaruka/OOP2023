using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    //フィートとメートルの単位変換クラス
    public static class FeetConverter { //staticメソッドしかない→staticクラスにしておけばインスタンスを作ろうとしたときにエラーが出るので、他開発者に向けたプログラムとして良い

        private const double ratio = 0.3048; //T:ratioはprivateだから全部小文字なんだと思う //T:constって書くと自動的にstaticになります
        //public static readonly double ratio = 0.3048; //p.58

        //メートルからフィートを求める
        public static double FromMeter(double meter) {
            return meter / ratio;
        }

        //フィートからメートルを求める
        public static double ToMeter(double feet) {
            return feet * ratio;
        }

    }
}
