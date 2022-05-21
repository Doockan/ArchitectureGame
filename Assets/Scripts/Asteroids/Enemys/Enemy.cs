using UnityEngine;

namespace Asteroids.Enemys
{
    internal abstract class Enemy : MonoBehaviour
    {
        public Health Health { get; set; }

        public static Asteroid CreateAsteroid(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        public static EnemyShip CreateEnemyShip(Health hp)
        {
            var enemy = Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
            enemy.Health = hp;
            return enemy;
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
    }
}

