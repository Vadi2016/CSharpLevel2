using System;
using System.Drawing;

namespace MyHomeWorkL2.Interface
{
    public interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
