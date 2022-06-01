using System;
using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Enemy
{
    public interface IEnemy : IMove, IRotate
    {
        event Action<int> OnTriggerEnterChange;
    }
}