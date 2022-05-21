using System;
using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    internal sealed class Asteroid : Enemy, IDamageDealer
    {
        public float Damage { get; set; }

        private void Awake()
        {
            Damage = 10f;
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