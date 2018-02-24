using System;
using System.Drawing;
using System.IO;

namespace MyHomeWorkL2
{
    
    /// <summary>
    /// класс астероид
    /// </summary>
    class Asteroid : BaseObject
    {
        public int Power { get; set; }  
        Image img;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            bool aster = Convert.ToBoolean(rnd.Next(0, 2));
            img = (aster == true) ? Properties.Resources.asteroid : Properties.Resources.aster2;
            Power = rnd.Next(5);
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 20, 20);
        }
        public void ChangePosition()
        {
            pos.X = 1000;
            pos.Y = rnd.Next(380);
        }

        internal static void MessageCreate(object o)
        {
            Console.WriteLine($"{DateTime.Now} Астероид создан, {o.GetType()} ");
        }
        internal static void MessageDestroy(object o)
        {
            Console.WriteLine($"{DateTime.Now} Астеройд уничтожен, { o.GetType()} ");
        }
    }
}
