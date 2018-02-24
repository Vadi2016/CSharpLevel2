using System;
using System.Drawing;
using System.IO;
namespace MyHomeWorkL2
{

    /// <summary>
    /// класс звезда, рандамно выбирает какую из двух картинок использовать
    /// </summary>
    public class Star : BaseObject
    {
        Image img; 
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bool aster = Convert.ToBoolean(rnd.Next(0, 2));
            img = (aster == true) ? Properties.Resources.star2 : Properties.Resources.star3;
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 20, 20);
       }
    }
}
