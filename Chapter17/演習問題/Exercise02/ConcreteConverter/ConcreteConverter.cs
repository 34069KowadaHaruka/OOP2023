﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    // List 17-13 (ConverterBaseの具象クラス)

    public class MeterConverter : ConverterBase {
        protected override double Ratio { get { return 1; } }
        public override string UnitName { get { return "メートル"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "meter" || name == UnitName;
        }
    }

    
    //以下、対メートルのRatioのみ記述(何から何に変換するにもメートルを経由するため)

    public class FeetConverter : ConverterBase {
        protected override double Ratio { get { return 0.3048; } }
        public override string UnitName { get { return "フィート"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "feet" || name == UnitName;
        }
    }

    public class InchConverter : ConverterBase {
        protected override double Ratio { get { return 0.0254; } }
        public override string UnitName { get { return "インチ"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "inch" || name == UnitName;
        }
    }

    public class YardConverter : ConverterBase {
        protected override double Ratio { get { return 0.9144; } }
        public override string UnitName { get { return "ヤード"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "yard" || name == UnitName;
        }
    }

    public class MileConverter : ConverterBase {
        protected override double Ratio { get { return 1609.344; } }
        public override string UnitName { get { return "マイル"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "mile" || name == UnitName;
        }
    }

    public class KiloMeterConverter : ConverterBase {
        protected override double Ratio { get { return 1000; } }
        public override string UnitName { get { return "キロメートル"; } }

        public override bool IsMyUnit(string name) {
            return name.ToLower() == "kilometer" || name == UnitName;
        }
    }
}
