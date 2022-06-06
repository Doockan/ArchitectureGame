using System;
using Asteroids.MVC.Data;
using Object = UnityEngine.Object;

namespace Asteroids.MVC.Enemy
{
    [Serializable]
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