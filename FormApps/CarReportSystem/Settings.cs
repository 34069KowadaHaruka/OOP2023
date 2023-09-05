using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    //設定情報 ..Singletonで実装
    public class Settings {
        public int MainFormColor { get; set; } //クラス型を直接シリアル化するため、Color構造体でなくint
        //自分自身のインスタンスを入れる変数
        private static Settings instance;

        //コンストラクタ
        private Settings(){}
        public static Settings getInstance() {
            if (instance == null) { //instanceがnullならインスタンスを作ってinstanceに入れ、既にあるなら何もしない
                instance = new Settings();
            }
            return instance; //instance変数を返す
        }
    }
}
