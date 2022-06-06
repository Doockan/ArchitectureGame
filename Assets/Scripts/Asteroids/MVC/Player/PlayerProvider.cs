using UnityEngine;

namespace Asteroids.MVC.Player
{
    public class PlayerProvider : MonoBehaviour
    {
        [SerializeField] private Transform _barrel;

        public Transform Barrel => _barrel;
    }
}