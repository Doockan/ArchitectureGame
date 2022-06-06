using System;
using System.Collections.Generic;
using Asteroids.MVC.Enemy;
using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Controller
{
    [Serializable]
    internal class EnemyInitialization : IInitialization
    {
        private readonly EnemyFactory _enemyFactory;
        private CompositeMove _enemyMove;
        private CompositeRotate _enemyRotate;
        private List<IEnemy> _enemies;

        public EnemyInitialization(EnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
            _enemyMove = new CompositeMove();
            _enemyRotate = new CompositeRotate();
            var enemy = _enemyFactory.CreateEnemy(EnemyType.SmallEnemyShip);
            _enemyMove.AddUnit(enemy);
            _enemyRotate.AddUnit(enemy);
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
            return _enemyMove;
        }

        public IRotate GetRotateEnemies()
        {
            return _enemyRotate;
        }
    }
}