using Asteroids.Interface;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids.Enemys
{
    internal sealed class EnemyShip : Enemy, IDamageDealer
    {
        public float Damage { get; set; }

        [SerializeField] private float maxRange;
        [SerializeField] private float overclockingForce;
        [SerializeField] private Transform barrel;
        [SerializeField] private float fireDelay;

        private float cooldownTimer = 0f;
        private IMove _moveSystem;
        private IRotation _rotationSystem;
        private GameObject _player;

        private AmmunitionPool _ammunitionPool;


        private void Start()
        {
            _ammunitionPool = GameStarter.AmmunitionPool;
            _moveSystem = gameObject.AddComponent<EnemyMove>();
            _player = GameObject.Find("Player");
            _rotationSystem = new EnemyRotation(transform);

            Damage = 10f;
        }

        private void Update()
        {
            _rotationSystem.Rotation(_player.transform.position);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);
            cooldownTimer -= Time.deltaTime;

            if (hit.collider.CompareTag("Player"))
            {
                if (cooldownTimer <= 0)
                {
                    cooldownTimer = fireDelay;

                    Ammunition Rockets = _ammunitionPool.GetAmmunition("Rockets");
                    Rockets.transform.position = barrel.position;
                    Rockets.transform.rotation = barrel.rotation;
                    Rockets.gameObject.SetActive(true);
                    Rockets.AddForce();
                }
            }

            if (Vector2.Distance(transform.position, _player.transform.position) > maxRange)
            {
                _moveSystem.AddForceForward(overclockingForce);
            }
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var dealer = other.gameObject.GetComponent<IDamageDealer>();
            Health.ChangeCurrentHealth(dealer.Damage);

            if (Health.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}