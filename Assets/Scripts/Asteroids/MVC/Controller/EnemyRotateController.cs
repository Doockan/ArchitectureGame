using Asteroids.MVC.Interface;
using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class EnemyRotateController : IExecute
    {
        private readonly IRotate _rotate;
        private readonly Transform _target;

        public EnemyRotateController(IRotate rotate, PlayerProvider target)
        {
            _rotate = rotate;
            _target = target.transform;
        }
        public void Execute(float deltaTime)
        {
            _rotate.Rotate(_target.position);
        }
    }
}