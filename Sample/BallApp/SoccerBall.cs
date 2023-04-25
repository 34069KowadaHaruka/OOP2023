﻿using System;
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
        //private static int count;

        //property
        //public static int Count { get => count; set => count = value; }

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
            
            //int randX = random.Next(-15,-15);
            //moveX = (randX != 0 ? randX : 1); //何やってるかわからないのでとりあえず使わぬ
        }

        //method
        public override void Move() {

            //Console.WriteLine("X座標 = {0}, Y座標 = {1}", PosX, PosY);
            
            if (PosX >= 730 && PosY >= 520) //四隅のうち右下しかカバーできてない
            {
                MoveX = -MoveX;
                MoveY = -MoveY;
            }
            else if (PosX >= 730 || PosX < 0)
            {
                MoveX = -MoveX;
            }
            else if (PosY >= 520 || PosY < 0)
            {
                MoveY = -MoveY;
            }

            PosX += MoveX;
            PosY += MoveY;
        }
    }
}
