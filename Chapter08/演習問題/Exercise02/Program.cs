using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dateTime = DateTime.Now.AddDays(7);
            var dayOfWeek = dateTime.DayOfWeek;
            var days = (int)dayOfWeek - (int)(dateTime.DayOfWeek);

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                if (days <= 0) {
                    days++;
                }
                dateTime = dateTime.AddDays(days);
                Console.WriteLine(dateTime.ToString("yyyy年 M月d日(dddd)", culture));
            }
        }
    }
}
