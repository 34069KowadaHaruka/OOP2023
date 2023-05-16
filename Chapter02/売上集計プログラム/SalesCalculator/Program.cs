using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) { //エントリーポイント
            //ReadSales("Sales.csv"); //ドライバ
            SalesCounter sales = new SalesCounter(@"data\sales.csv"); //これはここのSCインスタンスsalesとRS作業用salesが別物だからnewが要るの？
                //さっきの例は、例えば同じ配列の中身を変えれば済むような話だからってこと？
            IDictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
            }
        }
    }
}
