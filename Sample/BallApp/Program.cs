using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program :Form{

        private Timer moveTimer; //Timer用
        private SoccerBall soccerBall;
        private PictureBox pb;

        private List<SoccerBall> balls = new List<SoccerBall>(); //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>(); //表示用

        static void Main(string[] args) {

            Application.Run(new Program());
            //Applicationとメソッドって何が違うんだろ　C#のメソッドのシグネチャよく見なかったな
            //JavaでもApprication使えるのかな　C#で新しくでてきたやつかも
        }

        public Program() {
            //Form form = new Form();

            //this.Width = 1200; //幅
            //this.Height = 800; //高さ
            this.Size = new Size(800, 600);
            this.Text = "BallGame";
            this.BackColor = Color.Green;
            this.MouseClick += Program_MouseClick;
            //Width,Height,Textなど、()がついていないものはプロパティ(アクセサ的なもの)
            
            moveTimer = new Timer();
            moveTimer.Interval = 1; //タイマーのインターバル(ミリ秒)
            moveTimer.Tick += MoveTimer_Tick; //デリゲート登録(タイマーにメソッド呼び出しを依頼する感じ)
            
            //form.ShowDialog();
            //ShowDialogなどはメソッド
        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成
            soccerBall = new SoccerBall(e.X - 25, e.Y - 25);
            pb = new PictureBox(); //画像を表示するコントロール(部品、コンポーネント)
            pb.Image = soccerBall.Image;
            pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY); //画像の位置
            pb.Size = new Size(50, 50); //画像の表示サイズ
            pb.SizeMode = PictureBoxSizeMode.StretchImage; //画像の表示モード
            pb.Parent = this;//pbの親(Form)を登録
            this.Text = "BallGame：" + (balls.Count + 1);

            balls.Add(soccerBall);
            pbs.Add(pb);

            moveTimer.Start(); //タイマースタート
        }

        //タイマータイムアウト時のイベントハンドラ
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i].Move();
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
            }
            //soccerBall.Move(); //移動
            //pb.Location = new Point((int)soccerBall.PosX, (int)soccerBall.PosY); //画像の位置
        }
    }
}
