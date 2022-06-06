using Asteroids.MVC.Enemy;
using Asteroids.MVC.Interface;
using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class EnemyMoveController : IExecute
    {
        private readonly IMove _move;
        private readonly Transform _target;

        public EnemyMoveController(IMove move, PlayerProvider target)
        {
            _move = move;
            _target = target.transform;
        }

        public void Execute(float deltaTime)
        {
            _move.Move(_target.localPosition);
        }
    }
}