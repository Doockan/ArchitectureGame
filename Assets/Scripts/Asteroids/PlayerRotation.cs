﻿using Asteroids.Interface;
using UnityEngine;

namespace Asteroids
{
    public class PlayerRotation : IRotation
    {
        private Transform _transform;

        public PlayerRotation(Transform transform)
        {
            _transform = transform;
        }

        public void Rotation(Vector3 target)
        {
            Vector3 direction = Input.mousePosition - target.WorldToScreenPoint(_transform.position);
            var angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _transform.rotation = Quaternion.AngleAxis(angel - 90f, Vector3.forward);
        }
    }
}