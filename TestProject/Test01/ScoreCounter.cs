using System.Collections.Generic;
using System.IO;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要： スコアデータを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var students = new List<Student>(); //スコアデータを入れるリストオブジェクトを生成
            string[] lines = File.ReadAllLines(filePath); //ファイルから一気に読み込む
            foreach (string line in lines) { //読み込んだ行の数だけ繰り返す
                string[] items = line.Split(',');
                Student student = new Student { //Studentオブジェクトを生成
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                students.Add(student); //Studentオブジェクトをリストに追加
            }
            return students;
        }

        //メソッドの概要： 科目別スコアを求める
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>(); //科目ごとのスコアを入れるディクショナリーオブジェクトを生成
            foreach (Student student in _score) { //科目ごとのスコアを集計
                if (dict.ContainsKey(student.Subject)) {
                    dict[student.Subject] += student.Score;
                }
                else {
                    dict[student.Subject] = student.Score;
                }
            }
            return dict;
        }
    }
}
