using System;
using System.Drawing;

namespace MyHomeWorkL2
{
    
    /// <summary>
    /// класс галактика
    /// </summary>
    class Galaxy : BaseObject
    {
        Image img = Properties.Resources.home_galaxy;
        public Galaxy(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.buffer.Graphics.DrawImage(img, pos.X, pos.Y, 1200, 450);
        }
        public override void Update()
        {
        }
        public void Message(object o)
        {
            Console.WriteLine($"{DateTime.Now}  Галактика создана, {o.ToString()} ");
        }
    }
}
