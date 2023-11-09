using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class MetricMassUnit : DistanceUnit {
        private static List<MetricMassUnit> units = new List<MetricMassUnit> {
            new MetricMassUnit { Name="g", Coefficient=1, },
            new MetricMassUnit { Name="kg", Coefficient=1000, },
        };
        public static ICollection<MetricMassUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド→グラム
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>グラム単位</returns>

        public double FromImperialMassUnit(ImperialMassUnit unit, double value) {
            return (value * unit.Coefficient) / 0.03527 / this.Coefficient;
        }
    }
}
