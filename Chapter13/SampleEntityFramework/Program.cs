﻿using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    class Program {
        static void Main(string[] args) {
            //InsertBooks();

            //DisplayAllBooks();

            //AddAuthors();

            //AddBooks();
            //Console.Write("データを挿入しました。続けるにはEnterキーを押してください。");
            //Console.ReadLine();
            //Console.WriteLine();

            //using (var db = new BooksDbContext()){
            //    var count = db.Books.Count();
            //    Console.WriteLine(count);
            //}
            Console.WriteLine("# 1.1");
            Exercise1_1();

            Console.WriteLine();
            Console.WriteLine("# 1.2");
            Exercise1_2();

            Console.WriteLine();
            Console.WriteLine("# 1.3");
            Exercise1_3();

            Console.WriteLine();
            Console.WriteLine("# 1.4");
            Exercise1_4();

            Console.WriteLine();
            Console.WriteLine("# 1.5");
            Exercise1_5();

            Console.ReadLine();

            using (var db = new BooksDbContext()) {

                db.Database.Log = sql => { Debug.Write(sql); };

                var count = db.Books.Count();
                Console.WriteLine(count);
            }
        }

        private static void Exercise1_1() {
            throw new NotImplementedException();
        }

        private static void Exercise1_2() {
            throw new NotImplementedException();
        }

        private static void Exercise1_3() {
            throw new NotImplementedException();
        }

        private static void Exercise1_4() {
            throw new NotImplementedException();
        }

        private static void Exercise1_5() {
            throw new NotImplementedException();
        }

#region Methods

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);
                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                         .Where(book => book.Author.Name.StartsWith("夏目"))
                         .ToList();
            }
        }

        static void DisplayAllBooks() {
            var books = GetBooks();
            foreach (var book in books) {
                Console.WriteLine($"{book.Title}{book.PublishedYear}");
            }
            Console.ReadLine();
        }

        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                var author1 = new Author {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子",
                };
                db.Authors.Add(author1);
                var author2 = new Author {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治",
                };
                db.Authors.Add(author2);
                db.SaveChanges();
            }
        }

        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);
                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);
                db.SaveChanges();
            }
        }

        private static void UpdateBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }

        private static void DeleteBook() {
            using (var db = new BooksDbContext()) {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null) {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }
#endregion
    }
}
