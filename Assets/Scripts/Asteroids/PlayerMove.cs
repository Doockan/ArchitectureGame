using System;
using UnityEngine;
using Asteroids.Interface;

namespace Asteroids
{
    public class PlayerMove : MonoBehaviour, IMove
    {
        private readonly GameObject _gameObject;
        private Rigidbody2D _rigidbody2D;
        private Vector3 _move;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _move = transform.position;
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