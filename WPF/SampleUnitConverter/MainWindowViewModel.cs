using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double metricMassValue, imperialMassValue;

        //プロパティ
        public double MetricMassValue {
            get { return this.metricMassValue; }
            set { this.metricMassValue = value; this.OnPropertyChanged(); }
        }
        public double ImperialMassValue {
            get { return this.imperialMassValue; }
            set { this.imperialMassValue = value; this.OnPropertyChanged(); }
        }

        //上のComboBoxで選択されている値(単位)
        public MetricMassUnit CurrentMetricMassUnit { get; set; }
        public ImperialMassUnit CurrentImperialMassUnit { get; set; }

        //▲ボタンで呼ばれるコマンド
        public ICommand MetricToImperialMassUnit { get; set; }
        //▼ボタンで呼ばれるコマンド
        public ICommand ImperialToMetricMassUnit { get; set; }

        //コンストラクタ
        public MainWindowViewModel() {
            this.CurrentMetricMassUnit = MetricMassUnit.Units.First();
            this.CurrentImperialMassUnit = ImperialMassUnit.Units.First();

            this.MetricToImperialMassUnit = new DelegateCommand(
                () => this.ImperialMassValue = this.CurrentImperialMassUnit.FromMetricMassUnit(
                    this.CurrentMetricMassUnit, this.MetricMassValue
                )
            );
            this.ImperialToMetricMassUnit = new DelegateCommand(
                () => this.MetricMassValue = this.CurrentMetricMassUnit.FromImperialMassUnit(
                    this.CurrentImperialMassUnit, this.ImperialMassValue
                )
            );
        }
    }
}
