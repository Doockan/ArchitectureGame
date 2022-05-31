using UnityEngine;

namespace Asteroids.MVC.Player
{
    public interface IPlayerFactory
    {
        Transform CreatePlayer();
    }
}