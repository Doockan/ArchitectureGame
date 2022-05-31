using System;

namespace Asteroids.MVC.Interface
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}