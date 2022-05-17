using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    internal sealed class AsteroidFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}