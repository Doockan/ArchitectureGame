using UnityEngine;

namespace Asteroids.MVC.Model
{
    internal class PlayerModel : IPlayerModel
    {
        public Sprite Sprite { get; }
        public float Speed { get; }
        public Vector2Int Position { get; }
        public string Name { get; }

        public PlayerModel(Sprite sprite, float speed, Vector2Int position, string name)
        {
            Sprite = sprite;
            Speed = speed;
            Position = position;
            Name = name;
        }
    }
}