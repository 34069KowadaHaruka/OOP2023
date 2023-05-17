using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
        #region 自分の回答
        #if false
            int numOfSongs = 3;
            Song[] songs = SongStayOrganizing(numOfSongs);
            PrintSongs(songs, numOfSongs);
        #endif
        #endregion

            var songs = new Song[] {
                new Song("a","aa",243),
                new Song("s","ss",293),
                new Song("d","dd",276),
                new Song("f","ff",231),
                new Song("g","gg",273),
            };
            PrintSongs(songs);
            
            Console.WriteLine();

            var lists = new List<Song>();
            lists.Add(new Song("a", "aa", 243));
            lists.Add(new Song("s", "ss", 293));
            lists.Add(new Song("d", "dd", 276));
            lists.Add(new Song("f", "ff", 231));
            lists.Add(new Song("g", "gg", 273));
            PrintSongs(lists);
        }

        private static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var song in songs) {
                Console.WriteLine("{0},{1},{2:m\\:s}",
                    song.Title, song.ArtistName, TimeSpan.FromSeconds(song.Length));
            }
        }

        static Song[] SongStayOrganizing(int numOfSongs) {
            var songs = new Song[3];
            string[] items = new string[3];
            for (int i = 0; i < numOfSongs; i++) {
                Console.Write("歌のタイトル：");
                items[0] = Console.ReadLine();
                Console.Write("アーティスト名：");
                items[1] = Console.ReadLine();
                Console.Write("演奏時間：");
                items[2] = Console.ReadLine();

                Song song = new Song(items[0], items[1], int.Parse(items[2]));
                songs[i] = song;
            }
            return songs;
        }
        
        private static void PrintSongs(Song[] songs, int numOfSongs) {
            Console.WriteLine();
            Console.WriteLine("≪Songs - Data≫");
            for (int i = 0; i < numOfSongs; i++) {
                Console.Write(songs[i].Title + " / ");
                Console.Write(songs[i].ArtistName + "　-　");
                Console.Write("{0}:{1}", songs[i].Length/60, songs[i].Length % 60);
                Console.WriteLine();
            }
        }

        
    }
}
