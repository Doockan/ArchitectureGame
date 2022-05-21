using UnityEngine;

namespace Asteroids.Object_Pool
{
    public abstract class Ammunition : MonoBehaviour

    {
        public abstract void AddForce();
        
        private float Damage { get; set; }
        private float FiringRange { get; set; }
        private float RateOfFire { get; set; }
    }
}