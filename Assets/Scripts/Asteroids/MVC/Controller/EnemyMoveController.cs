using Asteroids.MVC.Enemy;
using Asteroids.MVC.Interface;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class EnemyMoveController : IExecute
    {
        private readonly IMove _move;
        private readonly Transform _target;

        public EnemyMoveController(IMove move, Transform target)
        {
            _move = move;
            _target = target;
        }

        public void Execute(float deltaTime)
        {
            _move.Move(_target.localPosition);
        }
    }
}