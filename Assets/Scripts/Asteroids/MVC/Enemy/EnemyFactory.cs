using Asteroids.MVC.Data;
using UnityEngine;

namespace Asteroids.MVC.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly EnemyData _data;


        public EnemyFactory(EnemyData data)
        {
            _data = data;
        }
    
        public IEnemy CreateEnemy(EnemyType type)
        {
            var enemyProvaider = _data.GetEnemy(type);
            return Object.Instantiate(enemyProvaider);
        }
    }
}