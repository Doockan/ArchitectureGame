using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Enemys
{
    internal sealed class EnemyShipFactory : IEnemyFactory
    {
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
            enemy.DependencyInjectHealth(hp);
            return enemy;
        }
    }
}