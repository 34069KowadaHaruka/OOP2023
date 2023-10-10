using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise04 {
    class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");
            var pattern = @"\s*=\s*";
            string result = string.Join(Environment.NewLine, lines);
            result.Replace(result, Regex.Replace(result, pattern, "="));
            result.Replace(result, Regex.Replace(result, @"[Vv]ersion=""v4.0""", @"version=""v5.0"""));
            
            //var newLine = lines.

            //File.WriteAllLines("sample.txt",newLine);

             // これ以降は確認用
            var text = File.ReadAllText("sample.txt");
            Console.WriteLine(text);
        }
    }
}
