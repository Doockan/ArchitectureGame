using Asteroids.MVC.Extention;
using Asteroids.MVC.Model;
using UnityEngine;

namespace Asteroids.MVC.Player
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IPlayerModel _playerData;

        public PlayerFactory(IPlayerModel playerData)
        {
            _playerData = playerData;
        }
    
        public PlayerProvider CreatePlayer()
        {
            var playerProvider = _playerData.Prefab;
            return Object.Instantiate(playerProvider);
        }
    }
}