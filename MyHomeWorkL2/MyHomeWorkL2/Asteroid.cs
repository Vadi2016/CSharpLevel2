using System;
using System.Drawing;
using System.IO;

namespace MyHomeWorkL2
{
    public class Asteroid : BaseObject
    {
        /// <summary>
        /// Конструктор астероида.
        /// </summary>
        /// <param name="pos">Позиция объекта.</param>
        /// <param name="dir">Направление.</param>
        /// <param name="size">Размер объекта.</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Переписанный виртуальный метод Update() изменения положения астероидов.
        /// </summary>
        public override void Draw()
        {
            string path = Path.GetFullPath("asteroid-icon.png");    // Путь к файлу

            Image newImage = Image.FromFile(path);
            Game.buffer.Graphics.DrawImage(newImage, pos.X, pos.Y, size.Width * 3, size.Height * 3);
        }

        /// <summary>
        /// Задание начальных координат при столкновении(регенерация)
        /// </summary>
        public override void New()
        {
            pos.X = Game.Width - 30;
            pos.Y = Game.Height / 2;
            string path = Path.GetFullPath("buum.png");    // Путь к файлу

            Image newImage = Image.FromFile(path);
            Game.buffer.Graphics.DrawImage(newImage, pos.X, pos.Y, size.Width * 3, size.Height * 3);
        }

        /// <summary>
        /// Переписанный метод положения астероида.
        /// </summary>
        public override void Update()
        {
            pos.X = pos.X - dir.X;
            if (pos.X > Game.Width || pos.X < 0) pos.X = Game.Width - 20;
            pos.Y = pos.Y - dir.Y;
            if (pos.Y > Game.Height || pos.Y < 0) pos.Y = Game.Height / 2;
        }
    }
}
