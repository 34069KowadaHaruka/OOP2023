using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class TennisBall : Obj {

        //field
        Random r = new Random();
        private static int count;
        
        //property
        public static int Count { get => count; set => count = value; }

        //constructor
        public TennisBall(double px, double py)
            : base(px, py, @"pic\tennis_ball.png") { //constructor

            PosX = px;
            PosY = py;

            do
            {
                MoveX = r.Next(5, 30);
                MoveY = r.Next(5, 30);
            } while (MoveX == 0 || MoveY == 0); //&&でもよかったのかも

            Count++;
            //int randX = random.Next(-15,-15); //変数randXにrandomの値を入れる
            //moveX = (randX != 0 ? randX : 1); //randXが0なら1に変える？
        }
       
        //method
        public override void Move() {

            if (PosX >= 740 || PosX < 0)
            {
                MoveX = -MoveX;
            }
            
            if (PosY >= 520 || PosY < 0)
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
