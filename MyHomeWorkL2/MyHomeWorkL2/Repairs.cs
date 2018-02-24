using System;
using System.Drawing;

namespace MyHomeWorkL2
{
    
    /// <summary>
    /// класс ремонт
    /// </summary>
    class Repairs : BaseObject
    {
        public int Power { get; set; }  // автоматическое свойство
        Image img = Properties.Resources.repaire;
        public Repairs(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = rnd.Next(5, 10);
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
    }
}
