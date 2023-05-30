using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    public class YearMonth {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public bool Is21Century { get {return 2001 <= Year && Year <= 2100;} }
            
        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        public YearMonth AddOneMonth() {
            if (Month == 12) {
                return new YearMonth(Year + 1, 1);
            }
            else {
                return new YearMonth(Year, Month + 1);
            }
            
            //return new YearMonth(Month == 12 ? Year + 1 : Year, Month == 12 ? 1 : Month + 1); //わかりにくいから↑でいい
        }

        public override string ToString() {
            string outStr = string.Format("{0}年{1}月", Year, Month);
            return outStr;
        }
    }
}
