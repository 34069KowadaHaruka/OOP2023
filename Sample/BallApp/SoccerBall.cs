using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class SoccerBall {
        //field
        private Image image; //画像データ

        private double posX; //x座標
        private double posY; //y座標

        private double moveX = 5.0; //x軸方向の移動量
        private double moveY = 3.0; //y軸方向の移動量

        public SoccerBall() { //constructor
            Image = Image.FromFile(@"pic\soccer_ball.png");
            PosX = 0.0;
            PosY = 0.0;
            
        }

        //property
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        public double MoveX { get => moveX; set => moveX = value; }
        public double MoveY { get => moveY; set => moveY = value; }

        //method
        public void Move() {

            if (PosX >= 750 && PosY >= 520)
            {
                moveX *= -1;
                moveY *= -1;
            }
            else if (PosX >= 750 || PosX <= -1)
            {
                moveX *= -1;
            }
            else if (PosY >= 520 || PosY <= -1)
            {
                moveY *= -1;
            }

            PosX += MoveX;
            PosY += MoveY;
        }
    }
}
