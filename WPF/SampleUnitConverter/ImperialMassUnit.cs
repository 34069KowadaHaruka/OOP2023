using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    public class ImperialMassUnit : DistanceUnit {
        private static List<ImperialMassUnit> units = new List<ImperialMassUnit> {
            new ImperialMassUnit { Name="oz", Coefficient=1},
            new ImperialMassUnit { Name="lb", Coefficient=16},
        };
        public static ICollection<ImperialMassUnit> Units { get { return units; } }

        /// <summary>
        /// グラム→ポンド
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns>ポンド単位</returns>

        public double FromMetricMassUnit(MetricMassUnit unit, double value) {
            return (value * unit.Coefficient) * 0.03527 / this.Coefficient;
        }
    }
}
