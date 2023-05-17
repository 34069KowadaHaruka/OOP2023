using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                PrintInchToMeterList(1, 10);
            }
            else {
                PrintMeterToInchList(1, 10);
            }
        }

        //フィートからメートルへの対応表を出力
        private static void PrintInchToMeterList(int start, int stop) {
            for (int inch = start; inch <= stop; inch++) {
                double meter = InchConverter.ToMeter(inch);
                Console.WriteLine("{0} ft = {1:0.0000}m", inch, meter);
            }
        }

        //メートルからフィートへの対応表を出力
        private static void PrintMeterToInchList(int start, int stop) {
            for (int meter = start; meter <= stop; meter++) {
                double inch = InchConverter.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000}ft", meter, inch);
            }
        }

    }
}
