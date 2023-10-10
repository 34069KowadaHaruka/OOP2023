using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise05 {
    class Program {
        static void Main(string[] args) {
            TagLower("sample.html");
        }

        private static void TagLower(string file) {
            var lines = File.ReadLines(file);
            var sb = new StringBuilder();

            foreach (var line in lines) {
                sb.AppendLine(Regex.Replace(line, @"<[^<>][A-Z]+[^<>]>", @"<[^<>]\l$1[^<>]>"));
                                                                  //↑ここに何か入れないと属性にも反映されそう
            }

            //ファイル出力
            File.WriteAllText(file, sb.ToString());

            var text = File.ReadAllText("sample.html");
            Console.WriteLine(text);
        }
    }
}
