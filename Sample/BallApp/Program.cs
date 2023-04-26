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
        private Bar bar;
        private Obj ballObj;

        private PictureBox pb;
        private PictureBox barPb;

        private List<Obj> balls = new List<Obj>(); //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>(); //表示用

        static void Main(string[] args) {

            Application.Run(new Program());
            //Applicationとメソッドって何が違うんだろ　C#のメソッドのシグネチャよく見なかったな
            //JavaでもApprication使えるのかな　C#で新しくでてきたやつかも
        }

        public Program() {
            //Form form = new Form(); //←Formを継承させたので、不要に

            //this.Width = 1200; //幅
            //this.Height = 800; //高さ
            this.Size = new Size(800, 600);
            this.Text = "BallGame S:0 T:0";
            this.BackColor = Color.Green;

            barPb = new PictureBox(); //画像を表示するコントロール(部品、コンポーネント)
            bar = new Bar(325, 400);
            barPb.Image = bar.Image;
            barPb.Location = new Point((int)bar.PosX, (int)bar.PosY); //画像の位置
            barPb.Size = new Size(150, 10);
            barPb.SizeMode = PictureBoxSizeMode.StretchImage; //画像の表示モード
            barPb.Parent = this;//pbの親(Form)を登録

            this.MouseClick += Program_MouseClick;

            this.KeyDown += Program_KeyDown;

            //Width,Height,Textなど、()がついていないものはプロパティ(アクセサ的なもの)
            
            moveTimer = new Timer();
            moveTimer.Interval = 1; //タイマーのインターバル(ミリ秒)
            moveTimer.Tick += MoveTimer_Tick; //デリゲート登録(タイマーにメソッド呼び出しを依頼する感じ)
            
            //form.ShowDialog();
            //ShowDialogなどはメソッド
        }

        //キーが押されたとき
        private void Program_KeyDown(object sender, KeyEventArgs e) {

            bar.Move(e.KeyData);
            barPb.Location = new Point((int)bar.PosX, (int)bar.PosY); //画像の位置

        }

        //マウスクリック時のイベントハンドラ
        private void Program_MouseClick(object sender, MouseEventArgs e) {

            pb = new PictureBox(); //画像を表示するコントロール(部品、コンポーネント)

            if (e.Button == MouseButtons.Right)
            {
                //ボールインスタンス生成
                ballObj = new TennisBall(e.X - 12, e.Y - 12);
                pb.Size = new Size(30, 30); //画像の表示サイズ
            }
            else
            {
                //ボールインスタンス生成
                ballObj = new SoccerBall(e.X - 25, e.Y - 25);
                pb.Size = new Size(50, 50); //画像の表示サイズ
            }

            
            pb.Image = ballObj.Image;
            pb.Location = new Point((int)ballObj.PosX, (int)ballObj.PosY); //画像の位置
            pb.SizeMode = PictureBoxSizeMode.StretchImage; //画像の表示モード
            pb.Parent = this;//pbの親(Form)を登録
            this.Text = "BallGame S:" + SoccerBall.Count +" T:" + TennisBall.Count;

            balls.Add(ballObj);
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