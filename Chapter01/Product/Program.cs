using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSample {
    class Program {
        static void Main(string[] args) {
            #region //P26のサンプルプログラム
            //    //インスタンス(オブジェクト)の生成
            //    Product karinto = new Product (123, "かりんとう", 180);
            //    Product daifuku = new Product(235, "大福もち", 160);
            //    //税込価格の表示
            //    Console.WriteLine("かりんとうの税込価格：" + karinto.GetPriceIncludingTax());
            //    Console.WriteLine("大福もちの税込価格：" + daifuku.GetPriceIncludingTax());
            #endregion
            #region //0508演習1
#if false
            DateTime date = DateTime.Today;

            //10日後を求める
            DateTime daysAfter10 = date.AddDays(10);
            DateTime daysBefore10 = date.AddDays(-10);

            Console.WriteLine("今日の日付：" + date.ToString("yyyy年MM月dd日"));
            Console.WriteLine("10日後：" + daysAfter10.ToString("yyyy年MM月dd日"));
            Console.WriteLine("10日前：" + daysBefore10.ToString("yyyy年MM月dd日"));
#endif
            #endregion
            #region //0508演習2
#if false
            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine();

            DateTime birthDay = new DateTime(year, month, day);
            DateTime toDay = DateTime.Today;

            TimeSpan interval = toDay - birthDay;

            Console.WriteLine();
            Console.WriteLine("あなたは生まれてから今日で" + interval.TotalDays + "日です。");
#endif
            #endregion
            #region //0509演習3
#if true
            string[] DowJapanese = { "日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日" };

            Console.WriteLine("誕生日を入力");
            Console.Write("西暦：");
            int year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            int month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine();

            DateTime birthDay = new DateTime(year, month, day);

            Console.WriteLine();
            Console.WriteLine("あなたは" + DowJapanese[(int)birthDay.DayOfWeek] + "に生まれました");


#endif
#endregion
        }
        
    }
}
