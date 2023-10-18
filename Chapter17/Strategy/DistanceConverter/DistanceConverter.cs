using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    // List 17-12
    public class DistanceConverter { //DistanceConverterがコンテキスト Strategyを含んでいる(集約 クラス内にStrategyのインスタンスを持つ)
    //Strategy役を利用する役 後出しじゃんけんの機構があったとして、アルゴリズムがあっても手が無きゃしょうがない
        public ConverterBase From { get; private set; }
        public ConverterBase To { get; private set; }

        public DistanceConverter(ConverterBase from, ConverterBase to) {
            From = from;
            To = to;
        }

        //ヤードからインチに変換する場合
        public double Convert(double value) {
            var meter = From.ToMeter(value); //ConverterBase型のヤードインスタンスにToMeterを実行させる
            return To.FromMeter(meter); //メートル単位になった元ヤードの値(ConverterBase型)のインスタンスにインチに向かうFromMeterを実行させる
        }
    }
}
