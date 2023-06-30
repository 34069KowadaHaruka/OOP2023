using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now; //2019, 1, 15, 19, 48, 32
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
            DisplayDatePattern3_2(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            var str = string.Format("{0:yyyy/M/d HH:mm}", dateTime);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            var str = string.Format("{0}年{1,2}月{2,2}日 {3,2}時{4,2}分{5,2}秒", dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var str = dateTime.ToString("ggyy年 M月d日(dddd)", culture);
            Console.WriteLine(str);
        }

        private static void DisplayDatePattern3_2(DateTime dateTime) {
            throw new NotImplementedException();
        }
    }
}
