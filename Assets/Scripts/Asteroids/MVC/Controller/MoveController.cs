using System.Data;
using Asteroids.MVC.Interface;
using Asteroids.MVC.Model;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class MoveController : IFixedExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IPlayerModel _unitData;
        private readonly IUserInputProxy _horizontalInputProxy;
        private readonly IUserInputProxy _verticalInputProxy;
        private float _horizontal;
        private float _vertical;
        private readonly Rigidbody2D _rigidBody2D;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input, Transform unit,
            IPlayerModel unitData)
        {
            _unit = unit;
            _unitData = unitData;
            
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;

            _rigidBody2D = unit.GetComponent<Rigidbody2D>();

            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        public void FixedExecute(float deltaTime)
        {
            if (_vertical > 0f)
            {
                _rigidBody2D.AddForce(_unit.transform.up * _unitData.Speed);    
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }
    }
}