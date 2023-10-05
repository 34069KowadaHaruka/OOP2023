﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise02 {
    class Program {
        static void Main(string[] args) {
            Pickup3DigitNumber("sample.txt");
        }

        private static void Pickup3DigitNumber(string file) {
#if false
            var regex = new Regex(@"^\d{3,}$");
            foreach (var line in File.ReadLines(file)) {
                var words = line.Split( );
                foreach (var word in words) {
                    var isMatch = regex.IsMatch(word);
                    if (isMatch)
                        Console.WriteLine(word);
                }
                
            }
#else
            var line = File.ReadAllText(file);
            var matches = Regex.Matches(line, @"\b\d{3,}\b");
            foreach (Match match in matches) {
                Console.WriteLine(match);
            }
#endif
        }
    }
}
