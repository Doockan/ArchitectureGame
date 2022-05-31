using UnityEngine;

namespace Asteroids.MVC.Enemy
{
    public interface IMove
    {
        void Move(Vector3 point);
    }
}