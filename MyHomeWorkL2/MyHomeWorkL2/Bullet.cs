using System;
using System.Drawing;
using System.IO;

namespace MyHomeWorkL2
{
    
    public class Bullet : BaseObject
    {
        delegate void Message();
        
        Image img = Properties.Resources.bullet;
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Переписанный виртуальный метод Update() изменения положения звезды.
        /// </summary>
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, size.Width * 3, size.Height * 3);
        }

        public override void Update()
        {
            pos.X = pos.X + 10;
        }
        public void ChangePosition()
        {
            pos.X = 1;
            pos.Y = rnd.Next(350);
        }
        public static void MessageShot(object o)
        {
            Console.WriteLine($"{DateTime.Now} Выстрел, {o.ToString()} ");
        }
    }
}
