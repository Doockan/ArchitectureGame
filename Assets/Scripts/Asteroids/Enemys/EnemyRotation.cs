using System;
using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    public class EnemyRotation : IRotation
    {
        private readonly Transform _transform;

        public EnemyRotation(Transform transform)
        {
            _transform = transform;
        }
        public void Rotation(Vector3 target)
        {
            var direction = target - _transform.position;
            float zAngel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion desireRot = Quaternion.Euler(0, 0, zAngel);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, desireRot, 180 * Time.deltaTime);
        }
    }
}