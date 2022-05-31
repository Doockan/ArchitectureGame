using System;
using Asteroids.MVC.Interface;
using Asteroids.MVC.Manager;
using UnityEngine;

namespace Asteroids.MVC.UserInput
{
    public class PCInputHorizontal : IUserInputProxy
    {
        public event Action<float> AxisOnChange = delegate(float f) {  };
        
        public void GetAxis()
        {
            AxisOnChange.Invoke(Input.GetAxis(AxisManager.HORIZONTAL));
        }
    }
}