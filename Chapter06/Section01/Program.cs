﻿using Chapter06;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9,7,5,4,2,5,4,0,4,1,0,4,};
            Console.WriteLine(numbers.Average());
            
            var books = Books.GetBooks();
            Console.WriteLine(books.Average(x => x.Price));
            Console.WriteLine(books.Average(x => x.Pages));
            Console.WriteLine(books.Max(x => x.Price));

            Console.WriteLine();

            //var booksObj = books.Where(x => x.Title.Contains("物語")).Average(x => x.Pages);
            //Console.WriteLine("{0}ページ", booksObj);

            //var booksObj = books.Where(x => x.Title.Contains("物語"))
            //                    .OrderByDescending(x => x.Price);
            //foreach (var book in booksObj) {
            //    Console.WriteLine("{0} {1}円", book.Title, book.Price);
            //}
            
            var booksObj = books.OrderByDescending(x=>x.Title.Length);
            //Console.WriteLine("{0}ページ", booksObj);
            foreach (var book in booksObj) {
                Console.WriteLine(book.Title);
            }
        }
    }
}
