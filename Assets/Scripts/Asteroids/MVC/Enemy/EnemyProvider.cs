using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids.MVC.Enemy
{
    public class EnemyProvider : MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        [SerializeField] private float _rotateSpeed;
        
        private Rigidbody2D _rigidbody2D;


        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 point)
        {
            if ((transform.position - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - transform.position).normalized;
                _rigidbody2D.AddForce(dir * _speed);
            }
        }

        public void Rotate(Vector3 point)
        {
            var dir = (point - transform.position).normalized;

            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, _rotateSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}