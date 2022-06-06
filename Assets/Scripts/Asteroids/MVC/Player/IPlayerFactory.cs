using UnityEngine;

namespace Asteroids.MVC.Player
{
    public interface IPlayerFactory
    {
        PlayerProvider CreatePlayer();
    }
}