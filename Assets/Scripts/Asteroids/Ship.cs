using System;
using Asteroids.Interface;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private float speed;
        [SerializeField] private float acceleration;
        [SerializeField] private float force;
        [SerializeField] private Transform barrel;

        private Camera _camera;

        private AmmunitionPool _ammunitionPool;

        private IInputSystem _inputSystem;
        private IHealth _health;

        private IMove _moveSystem;
        private IRotation _rotationSystem;

        private void Awake()
        {
            _health = new Health(100, 100);
            _camera = Camera.main;
            _inputSystem = new InputSystem();
            _moveSystem = new MoveTransform(transform, speed);
            _rotationSystem = new RotationTransform(transform);
            _ammunitionPool = new AmmunitionPool(10);

        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

            _rotationSystem.Rotation(direction);
            _moveSystem.Move(_inputSystem.Axis.x, _inputSystem.Axis.y, Time.deltaTime);

            if (_inputSystem.IsAttackButtonUp())
            {
                Fire();
            }
        }

        public void Fire()
        {
            Ammunition Rockets = _ammunitionPool.GetAmmunition("Rockets");
            Rockets.transform.position = barrel.position;
            Rockets.transform.rotation = barrel.rotation;
            Rockets.gameObject.SetActive(true);
            Rockets.onCollision.AddListener(_ammunitionPool.ReturnToPool);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("PlayerMissile"))
            {
                if (_health.CurrentHealth <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Damage 5");
                    _health.ChangeCurrentHealth(5);
                }
            }
        }
    }
}