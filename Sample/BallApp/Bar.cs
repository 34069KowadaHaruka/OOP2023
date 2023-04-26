using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class Bar {

        //field
        private Image image; //画像データ
        private double posX; //x座標
        private double posY; //y座標
        private double moveX; //x軸方向の移動量

        //propaty
        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        public double MoveX { get => moveX; set => moveX = value; }

        //constructor
        public Bar(double px, double py) {

            this.PosX = px;
            this.PosY = py;

            Image = Image.FromFile(@"pic\bar.png");

        }

        //method
        public void Move(int direction) {

            MoveX = 10;
            MoveX *= direction;
            
            if ((PosX >= 630 && MoveX > 0) || PosX < 0 && MoveX < 0)
            {
                MoveX = 0;
            }

            PosX += MoveX;
           
        }
    }
}
