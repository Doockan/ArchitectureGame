using Asteroids.MVC.Interface;
using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private PlayerProvider _player;

        public PlayerInitialization(IPlayerFactory playerFactory, Vector2 positionPlayer)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            _player.transform.position = positionPlayer;
        }
        
        public void Initialization()
        {
        }

        public PlayerProvider GetPlayer()
        {
            return _player;
        }
    }
}