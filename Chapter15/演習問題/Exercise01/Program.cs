﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var max = Library.Books.Max(b => b.Price);
            var book = Library.Books
                              .First(b => b.Price == max);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var groups = Library.Books
                                .GroupBy(b => b.PublishedYear);
            int count = 0;
            foreach (var g in groups) {
                Console.Write($"{g.Key}年：");
                foreach (var book in g) {
                    count++;
                }
                Console.WriteLine(count+"冊");
            }
            //LINQを使おう
        }

        private static void Exercise1_4() {
            var books = Library.Books
                               .OrderByDescending(b => b.PublishedYear)
                               .ThenByDescending(b => b.Price);
            foreach (var book in books) {
                Console.WriteLine("{0}年 {1}円 {2}({3})"
                                    ,book.PublishedYear
                                    ,book.Price
                                    ,book.Title
                                    ,Library.Categories.Where(c => c.Id.Equals(book.CategoryId)).Select(c => c.Name));
            }
            //カテゴリーネームが表示できてない
        }

        private static void Exercise1_5() {
        }

        private static void Exercise1_6() {
        }

        private static void Exercise1_7() {
        }

        private static void Exercise1_8() {
        }
    }
}
