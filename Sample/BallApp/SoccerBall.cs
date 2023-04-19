using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class SoccerBall {
        //field
        Random r = new Random();
        private Image image; //画像データ

        private double posX; //x座標
        private double posY; //y座標

        private double moveX; //x軸方向の移動量
        private double moveY; //y軸方向の移動量

        public SoccerBall(double px, double py) { //constructor
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = px;
            PosY = py;

            do{
                MoveX = r.Next(-20, 20);
                MoveY = r.Next(-20, 20);
            } while (MoveX == 0 || MoveY == 0); //&&でもよかったのかも

            //int randX = random.Next(-15,-15);
            //moveX = (randX != 0 ? randX : 1); //何やってるかわからないのでとりあえず使わぬ
        }

        //property
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        public double MoveX { get => moveX; set => moveX = value; }
        public double MoveY { get => moveY; set => moveY = value; }

        //method
        public void Move() {

            if (PosX >= 750 && PosY >= 520) //四隅のうち右下しかカバーできてない
            {
                moveX = -moveX;
                moveY = -moveY;
            }
            else if (PosX >= 750 || PosX < 0)
            {
                moveX = -moveX;
            }
            else if (PosY >= 520 || PosY < 0)
            {
                moveY = -moveY;
            }

            PosX += MoveX;
            PosY += MoveY;
        }
    }
}
