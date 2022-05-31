using System;

namespace Asteroids.MVC.Enemy
{
    public interface IEnemy : IMove
    {
        event Action<int> OnTriggerEnterChange;
    }
}