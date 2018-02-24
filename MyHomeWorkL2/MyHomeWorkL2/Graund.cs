using System;
using System.Drawing;

namespace MyHomeWorkL2
{
    
    /// <summary>
    /// класс земля
    /// </summary>
    class Graund : BaseObject
    {
        Image img = Properties.Resources.pluto;
        public Graund(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 2000, 150);
        }
        public override void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < -1000)
            {
                pos.X = 0;
            }
        }
        public void Message(object o)
        {
            Console.WriteLine($"{DateTime.Now} Земля создана, { o.GetType()} ");
        }
    }
}
