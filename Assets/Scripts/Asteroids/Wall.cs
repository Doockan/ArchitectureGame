using Asteroids.Interface;
using UnityEngine;

namespace Asteroids
{
    public class Wall : MonoBehaviour, IDamageDealer
    {
        public float Damage { get; set; }

        private void Awake()
        {
            Damage = 200f;
        }
    }
}