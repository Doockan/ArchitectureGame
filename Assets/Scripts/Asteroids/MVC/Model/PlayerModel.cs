using UnityEngine;

namespace Asteroids.MVC.Model
{
    internal class PlayerModel : IPlayerModel
    {
        public Sprite Sprite { get; }
        public float Speed { get; }
        public float RotateSpeed { get; }
        public Vector2Int Position { get; }
        public string Name { get; }

        public PlayerModel(Sprite sprite, float speed, float rotateSpeed, Vector2Int position, string name)
        {
            Sprite = sprite;
            Speed = speed;
            RotateSpeed = rotateSpeed;
            Position = position;
            Name = name;
        }
    }
}