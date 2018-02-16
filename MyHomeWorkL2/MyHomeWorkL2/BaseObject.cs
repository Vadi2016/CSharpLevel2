using System;
using System.Drawing;
namespace MyHomeWorkL2
{
    public class BaseObject
    {
        protected Point pos;
        protected Point dir;
        protected Size size;
        /// <summary>
        /// Конструктор звезды.
        /// </summary>
        /// <param name="pos">Позиция объекта.</param>
        /// <param name="dir">Направление.</param>
        /// <param name="size">Размер объекта.</param>
        public BaseObject(Point pos, Point dir, Size size)
        {
            this.pos = pos;
            this.dir = dir;
            this.size = size;
        }
        /// <summary>
        /// Виртуальный метод вывода звезд.
        /// </summary>
        virtual public void Draw()
        {
            DrawCrossStar();
        }
        /// <summary>
        /// Виртуальный метод изменения положения.
        /// </summary>
        virtual public void Update()
        {
            pos.X = pos.X + dir.X;
            if (pos.X < 0) pos.X = Game.Width + size.Width;
        }
        /// <summary>
        /// Виртуальный метод создания звезд.
        /// </summary>
        virtual public void DrawCrossStar()
        {
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X, pos.Y, pos.X + size.Width, pos.Y + size.Height);
            Game.buffer.Graphics.DrawLine(Pens.White, pos.X + size.Width, pos.Y, pos.X, pos.Y + size.Height);
        }
    }
}
