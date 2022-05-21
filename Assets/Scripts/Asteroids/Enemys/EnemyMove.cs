using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    public class EnemyMove: MonoBehaviour, IMove
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }

        public void AddForceForward(float force)
        {
            _rigidbody2D.AddForce(gameObject.transform.up * force);
        }

        public void AddAcceleration(float force)
        {
            _rigidbody2D.AddForce(gameObject.transform.up * force);
        }
    }
}