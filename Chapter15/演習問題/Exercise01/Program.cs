using System;
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
#if true
            var book = Library.Books
                              .First(b => b.Price == max);
            Console.WriteLine(book);
#else
            var books = Library.Books
                              .Where(b => b.Price == max);
            
            foreach (var book in books) {
                Console.WriteLine(book);
            }
#endif
        }

        private static void Exercise1_3() {
            var query = Library.Books
                                .GroupBy(b => b.PublishedYear)
                                .Select(g => new {
                                    PublishedYear = g.Key,
                                    Count = g.Count()
                                })
                                .OrderBy(x => x.PublishedYear);
            foreach (var q in query) {
                Console.WriteLine("{0}年：{1}冊", q.PublishedYear, q.Count);
            }
        }

        private static void Exercise1_4() {
            var books = Library.Books
                               .Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => new {
                                            Title = book.Title,
                                            Category = category.Name,
                                            Price = book.Price,
                                            PublishedYear = book.PublishedYear
                                        }
                                )
                               .OrderByDescending(b => b.PublishedYear)
                               .ThenByDescending(b => b.Price);
            foreach (var book in books) {
                Console.WriteLine("{0}年 {1}円 {2} ({3})"
                                    ,book.PublishedYear
                                    ,book.Price
                                    ,book.Title
                                    ,book.Category);
            }
        }

        private static void Exercise1_5() {
            var books = Library.Books
                               .Where(b => b.PublishedYear == 2016) //これを先に持ってくればPublishedYearをJoinで取ってこなくて良くなる
                               .Join(Library.Categories,
                                    book => book.CategoryId,
                                    category => category.Id,
                                    (book, category) => new {
                                        Category = category.Name
                                    }).Distinct();
            Console.WriteLine("2016年に発行された書籍のカテゴリ一覧");
            foreach (var book in books) {
                Console.WriteLine(book.Category);
            }
        }

        private static void Exercise1_6() {
            var query = Library.Books
                               .Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => new {
                                            Title = book.Title,
                                            PublishedYear = book.PublishedYear,
                                            Price = book.Price,
                                            Category = category.Name
                                         })
                               .GroupBy(c => c.Category).OrderBy(c => c.Key);
            foreach (var group in query) {
                Console.WriteLine("#{0}", group.Key);
                foreach (var book in group) {
                    Console.WriteLine("  {0}", book.Title);
                }
            }
        }

        private static void Exercise1_7() {
            var pYears = Library.Books.OrderBy(p => p.PublishedYear).Select(p => p.PublishedYear).Distinct();
            var lookup = Library.Books.Join(Library.Categories,
                                        book => book.CategoryId,
                                        category => category.Id,
                                        (book, category) => new {
                                            Title = book.Title,
                                            Category = category.Name,
                                            PublishedYear = book.PublishedYear
                                        })
                               .Where(b => b.Category == "Development")
                               .ToLookup(b => b.PublishedYear);
            foreach (var pYear in pYears) {
                var key = lookup[pYear];
                if (key.Count() == 0) {
                    continue;
                }
                Console.WriteLine("#" + pYear);
                foreach (var book in key) {
                    Console.WriteLine("  " + book.Title);
                }
            }
        }

        private static void Exercise1_8() {
            var groups = Library.Categories
                                .GroupJoin(Library.Books,
                                    c => c.Id,
                                    b => b.CategoryId,
                                    (c, books) => new { Category = c.Name, Books = books }
                                )
                                .Where(x => x.Books.Count() >= 4);
            foreach (var item in groups) {
                Console.WriteLine(item.Category);
            }
        }
    }
}
