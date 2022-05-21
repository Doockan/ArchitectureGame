using System;
using Asteroids.Interface;
using Asteroids.Object_Pool;
using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private float accelerationForce;
        [SerializeField] private float overclockingForce;
        [SerializeField] private Transform barrel;

        private Camera _camera;

        private AmmunitionPool _ammunitionPool;

        private IHealth _health;

        private IInputSystem _inputSystem;
        private IMove _moveSystem;
        private IRotation _rotationSystem;
        private IMouse _mouseSystem;

        private void Start()
        {
            _mouseSystem = new Mouse();
            _inputSystem = new InputSystem();
            _rotationSystem = new PlayerRotation(transform);
            _ammunitionPool = GameStarter.AmmunitionPool;
            _health = new Health(hp, hp);

            _moveSystem = gameObject.AddComponent<PlayerMove>();
            _camera = Camera.main;
        }

        public void Fire()
        {
            Ammunition Rockets = _ammunitionPool.GetAmmunition("Rockets");
            Rockets.transform.position = barrel.position;
            Rockets.transform.rotation = barrel.rotation;
            Rockets.gameObject.SetActive(true);
            Rockets.AddForce();
        }

        private void Update()
        {
            _rotationSystem.Rotation(_mouseSystem.DirectionFromShip(_camera, transform.position));

            if (_inputSystem.IsAttackButtonUp())
            {
                Fire();
            }

            if (_inputSystem.IsForwardButtonUp())
            {
                _moveSystem.AddForceForward(overclockingForce);
            }

            if (_inputSystem.IsAccelerationButtonUp())
            {
                _moveSystem.AddAcceleration(accelerationForce);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var dealer = other.gameObject.GetComponent<IDamageDealer>();
            _health.ChangeCurrentHealth(dealer.Damage);

            if (_health.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}