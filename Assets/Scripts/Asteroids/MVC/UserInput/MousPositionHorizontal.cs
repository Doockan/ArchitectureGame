using System;
using Asteroids.MVC.Interface;
using UnityEngine;

namespace Asteroids.MVC.UserInput
{
    public class MousPositionHorizontal : IUserMousPosition
    {
        public event Action<float> PositionOnChange = delegate(float f) {  };
    
        public void GetPosition()
        {
            PositionOnChange.Invoke(Input.mousePosition.x);
        }
    }
}