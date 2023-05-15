﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) { //エントリーポイント
            //ReadSales("Sales.csv"); //ドライバ
            SalesCounter sales = new SalesCounter(ReadSales(@"data\sales.csv"));
            Dictionary<string, int> amountPerStore = sales.GetPerStoreSales();
            foreach (KeyValuePair<string, int> obj in amountPerStore) {
                Console.WriteLine("{0} {1:C}", obj.Key, obj.Value);
            }
        }

        //売上データを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>(); //売上データを格納する
            string[] lines = File.ReadAllLines(filePath); //ファイルからすべてのデータを読み込む
            
            foreach (string line in lines) //すべてのデータ行から1行ずつ順に取り出す
            {
                string[] items = line.Split(','); //,区切りで項目別に分ける
                Sale sale = new Sale { //Saleオブジェクト(インスタンス)を生成
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale); //Saleインスタンスをコレクションに追加
            }
            //Sale型のList salesの要素1つにはSaleオブジェクト1つ(つまり要素3つの配列)が入っている
            return sales;
        }

    }
}
