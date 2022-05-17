using Asteroids.Object_Pool;
using UnityEngine;
using UnityEngine.Events;

namespace Asteroids
{
    public class Rockets : Ammunition
    {
        private Rigidbody2D _rigidbody2D;

        private void Start()
        {
            onCollision = new UnityEvent<Transform>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.AddForce(transform.up * 50f);
        }

        private void OnCollisionEnter2D()
        {
            Debug.Log("TUK");
            onCollision.Invoke(gameObject.transform);
        }
    }
}