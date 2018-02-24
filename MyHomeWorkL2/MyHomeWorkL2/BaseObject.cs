using System;
using System.Drawing;
using MyHomeWorkL2.Interface;

namespace MyHomeWorkL2
{

    delegate void Message();

    public abstract class BaseObject : ICollision
    {
        
            protected Point pos;
            protected Point dir;
            protected Size size;
            static protected Random rnd = new Random();

            public BaseObject(Point pos, Point dir, Size size)
            {
                this.pos = pos;
                this.dir = dir;
                this.size = size;
            }

            public int PosX
            {
                get { return pos.X; } // для обработки ошибок открыт доступ, потом убрать
                set { pos.X = value; } // { if (value > 0) pos.X = value; }
            }
            public int PosY
            {
                set { if (value > 0) pos.X = value; }
            }

            /// <summary>
            //    абстрактный клас, без тела, должен быть реализовон в потомке 
            //    </summary>
            public abstract void Draw(); //

            /// <summary>
            /// виртуальный класc для обновления позиции любого объекта
            /// </summary>
            public virtual void Update()
            {

                pos.X = pos.X + dir.X;
                pos.Y = pos.Y + dir.Y;
                if (pos.X < 0)
                {
                    pos.X = Game.Width;
                    pos.Y = rnd.Next(350);
                }
            }

            /// <summary>
            /// метод обнаружения пересечения с объектом
            /// </summary>
            /// <param name="o"> переданный в метод объект</param>
            /// <returns></returns>
            public bool Collision(ICollision o)
            {
                if (o.Rect.IntersectsWith(this.Rect)) return true; else return false;
            }

            public Rectangle Rect
            {
                get { return new Rectangle(pos, size); }
            }

    }
}
