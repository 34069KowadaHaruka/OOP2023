using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section03 {
    class Program {
        static void Main(string[] args) {
            var list = new List<string> {
               "Tokyo", "New Delhi", "Bangkok", "London", 
               "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            #region p90まで
            //var exists = list.Exists(s => s[2] == 'k');
            //Console.WriteLine(exists);

            //var name = list.Find(s => s.Length == 6);
            //Console.WriteLine(name);

            //var index = list.FindIndex(s => s.Length == 6);
            //var index = list.FindIndex(s => s == "Hong Kong");
            //Console.WriteLine(index);

            //var names = list.FindAll(s => s.Length <= 5);
            //var names = list.ConvertAll(s => s.ToLower());
            //foreach (var name in names) {
            //    Console.WriteLine(name);
            //}
            //names.ForEach(s => Console.WriteLine(s)); //names.ForEach(Console.WriteLine); //←可

            #endregion
        }
    }
}
