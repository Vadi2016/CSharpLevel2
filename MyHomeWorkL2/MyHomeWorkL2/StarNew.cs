using System;
using System.Drawing;

namespace MyHomeWorkL2
{
    public class StarNew : BaseObject
    {
        /// <summary>
        /// Конструктор звезды.
        /// </summary>
        /// <param name="pos">Позиция объекта.</param>
        /// <param name="dir">Направление.</param>
        /// <param name="size">Размер объекта.</param>
        public StarNew(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Переписанный метод Draw() вывода звезд.
        /// </summary>
        public override void Draw()
        {
            DrawCrossStar();
        }
        /// <summary>
        /// Переписанный виртуальный метод Update() изменения положения звезды.
        /// </summary>
        public override void Update()
        {
            // pos.X = pos.X + dir.X;
            //if (pos.X < 0) pos.X = Game.Width + size.Width + 10;

            pos.X = pos.X + dir.X;
            if (pos.X > Game.Width || pos.X < 0) pos.X = Game.Width / 2;
            pos.Y = pos.Y + dir.Y;
            if (pos.Y > Game.Height || pos.Y < 0) pos.Y = Game.Height / 2;
        }
        /// <summary>
        /// Переписанный виртуальный метод DrawCrossStar() создания звезды.
        /// </summary>
        public override void DrawCrossStar()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }

        public override void New() { }
    }
}
