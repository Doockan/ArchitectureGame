using System;
using Asteroids.MVC.Interface;
using Asteroids.MVC.Model;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class RotateController : IExecute, ICleanup
    {
        private readonly Transform _transform;
        private readonly Camera _camera;
        private readonly IPlayerModel _unitData;
        private readonly IUserMousPosition _horizontalMous;
        private readonly IUserMousPosition _verticalMousPosition;
        private float _horizontal;
        private float _vertical;

        public RotateController((IUserMousPosition positionHorizontal, IUserMousPosition positionVertical) mousPosition, Transform transform, Camera camera, IPlayerModel unitData)
        {
            _horizontalMous = mousPosition.positionHorizontal;
            _verticalMousPosition = mousPosition.positionVertical;
            
            _transform = transform;
            _camera = camera;
            _unitData = unitData;

            _horizontalMous.PositionOnChange += HorizontalMousOnPositionOnChange;
            _verticalMousPosition.PositionOnChange += VerticalOnPositionOnChange;
        }

        public void Execute(float deltaTime)
        {
            var dir = (_camera.ScreenToWorldPoint(new Vector3(_horizontal, _vertical, 0f)) -  _transform.position).normalized;
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, desiredRot, _unitData.RotateSpeed * deltaTime);
        }

        private void HorizontalMousOnPositionOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnPositionOnChange(float value)
        {
            _vertical = value;
        }


        public void Cleanup()
        {
            _horizontalMous.PositionOnChange -= HorizontalMousOnPositionOnChange;
            _verticalMousPosition.PositionOnChange -= VerticalOnPositionOnChange;
        }
    }

    public class Mous
    {
        public event Action<bool> FireOnClick;
    
        public void GetPosition()
        {
        
        }
    
    }
}