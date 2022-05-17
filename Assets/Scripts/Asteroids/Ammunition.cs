using UnityEngine;
using UnityEngine.Events;

namespace Asteroids
{
    public abstract class Ammunition : MonoBehaviour

    {
        public UnityEvent<Transform> onCollision;

        private float Damage { get; set; }
        private float FiringRange { get; set; }
        private float RateOfFire { get; set; }
    }
}