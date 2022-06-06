using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Model
{
    public interface IPlayerModel
    {
        public PlayerProvider Prefab { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public Vector2Int Position { get; }
        public string Name { get; }
    }
}