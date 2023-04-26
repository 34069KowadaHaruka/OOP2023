using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class SoccerBall : Obj {

        //field
        Random r = new Random();
        private static int count;

        //property
        public static int Count { get => count; set => count = value; }

        //constructor
        public SoccerBall(double px, double py) 
            : base(px, py, @"pic\soccer_ball.png") { //constructor
           
            PosX = px;
            PosY = py;
            
            do
            {
                MoveX = r.Next(-20, 20);
                MoveY = r.Next(-20, 20);
            } while (MoveX == 0 || MoveY == 0); //&&でもよかったのかも

            Count++;
            //int randX = random.Next(-15,-15);
            //moveX = (randX != 0 ? randX : 1); //何やってるかわからないのでとりあえず使わぬ
        }

        //method
        public override void Move() {

            //Console.WriteLine("X座標 = {0}, Y座標 = {1}", PosX, PosY);
            
            if (PosX >= 740 || PosX < 0)
            {
                MoveX = -MoveX;
            }
            
            if (PosY >= 520 || PosY < -10)
            {
                MoveY = -MoveY;
            }

            PosX += MoveX;
            PosY += MoveY;
        }

        public override void Move(Keys direction) {
            ;
        }
    }
}
