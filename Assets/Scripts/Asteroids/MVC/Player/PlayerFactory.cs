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
    
        public Transform CreatePlayer()
        {
            return new GameObject(_playerData.Name)
                .AddSprite(_playerData.Sprite)
                .AddPolygonCollider2D()
                .AddRigidbody2D(100f,0f)
                .transform;
        }
    }
}