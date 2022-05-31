using System.Collections.Generic;
using Asteroids.MVC.Enemy;
using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Controller
{
    internal class EnemyInitialization : IInitialization
    {
        private readonly EnemyFactory _enemyFactory;
        private CompositeMove _enemy;
        private List<IEnemy> _enemies;

        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemy = new CompositeMove();
            var enemy = _enemyFactory.CreateEnemy(EnemyType.SmallEnemyShip);
            _enemy.AddUnit(enemy);
            _enemies = new List<IEnemy>
            {
                enemy
            };
        }

        public void Initialization()
        {
        }

        public IMove GetMoveEnemies()
        {
            return _enemy;
        }
    }
}