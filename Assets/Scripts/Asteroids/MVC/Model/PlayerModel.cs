using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Model
{
    internal class PlayerModel : IPlayerModel
    {
        public PlayerProvider Prefab { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public Vector2Int Position { get; }
        public string Name { get; }

        public PlayerModel(PlayerProvider prefab, float speed, float rotateSpeed, Vector2Int position, string name)
        {
            Prefab = prefab;
            Speed = speed;
            RotateSpeed = rotateSpeed;
            Position = position;
            Name = name;
        }
    }
}