using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    class Program {
        static void Main(string[] args) {
            ToHankakuProcessor hankaku = new ToHankakuProcessor();
            TextProcessor processor = new TextProcessor(hankaku);
            processor.Run(@"Sample.txt");
        }
    }
}
