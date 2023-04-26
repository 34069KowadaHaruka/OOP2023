using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Bar : Obj {

        //constructor
        public Bar(double px, double py) :base(px, py, @"pic\bar.png") {

            this.PosX = px;
            this.PosY = py;

        }

        //method
        public override void Move(Keys direction) {

            if (direction == Keys.Right)
            {
                MoveX = 15;
            }
            else if (direction == Keys.Left)
            {
                MoveX = -15;
            }
            else
            {
                ;
            }
            
            if ((PosX >= 630 && MoveX > 0) || PosX < 0 && MoveX < 0)
            {
                MoveX = 0;
            }

            PosX += MoveX;
           
        }

        public override void Move(PictureBox pbBar, PictureBox pbBall) {
            ;
        }
    }
}
