using System;

namespace Asteroids.MVC.Interface
{
    public interface IUserMousPosition
    {
        event Action<float> PositionOnChange;
        void GetPosition();
    }
}