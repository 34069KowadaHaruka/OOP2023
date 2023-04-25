using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallApp {
    class Bar {
        private Image image; //画像データ

        private double posX; //x座標
        private double posY; //y座標
        private double moveX; //x軸方向の移動量

        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        public double MoveX { get => moveX; set => moveX = value; }
    }
}
