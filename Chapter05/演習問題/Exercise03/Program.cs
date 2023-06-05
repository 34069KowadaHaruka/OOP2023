using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {

            var text = "Jackdaws love my big sphinx of quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
        
        }

        private static void Exercise3_1(string text) {
            int spaces = text.Count(c => c == ' '); //c = char
            Console.WriteLine("空白数：{0}", spaces);
        }

        private static void Exercise3_2(string text) {
            var replaced = text.Replace("big", "small");
            Console.WriteLine(replaced);
        }

        private static void Exercise3_3(string text) {
            //string[] words = text.Split(' ');
            //Console.WriteLine(words.Length);
            int count = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}", count);
        }

        private static void Exercise3_4(string text) {
            //string[] words = text.Split(' ');
            var words = text.Split(' ').Where(word => word.Length <= 4);
            foreach (var word in words)
                Console.WriteLine(word);
            #region 自解答foreach部分
#if false
            foreach (var word in words) {
                if (word.Length <= 4) {
                    Console.WriteLine(word);
                }
            }
#endif
            #endregion
        }

        private static void Exercise3_5(string text) {
            var array = text.Split(' ').ToArray();
            var sb = new StringBuilder(array[0]);
            foreach (var word in array.Skip(1)) {
                sb.Append(" " + word);
            }
            var createWords = sb.ToString();
            Console.WriteLine(createWords);
            //TrimEndなどで空白を除くと、string文字列は2つできてしまう
        }
    }
}
