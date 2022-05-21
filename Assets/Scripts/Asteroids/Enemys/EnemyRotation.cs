using System;
using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    public class EnemyRotation : MonoBehaviour, IRotation
    {
        public void Rotation(Vector3 direction)
        {
            float zAngel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

            Quaternion desireRot = Quaternion.Euler(0, 0, zAngel);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desireRot, 180 * Time.deltaTime);
        }
    }
}