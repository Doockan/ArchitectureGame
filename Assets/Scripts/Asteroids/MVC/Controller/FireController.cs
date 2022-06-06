using Asteroids.MVC.Interface;
using Asteroids.MVC.Model;
using Asteroids.MVC.Player;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class FireController : IExecute
    {
        private readonly AmmunitionPool _ammunitionPool;
        private readonly Transform _barrel;

        public FireController(AmmunitionPool ammunitionPool, PlayerProvider unit)
        {
            _ammunitionPool = ammunitionPool;
            _barrel = unit.Barrel.transform;
        }


        public void Execute(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
        }

        private void Fire()
        {
            var rocket = _ammunitionPool.GetAmmunition("Rockets");
            rocket.transform.position = _barrel.position;
            rocket.transform.rotation = _barrel.rotation;
            rocket.gameObject.SetActive(true);
            rocket.AddForce();
        }
    }
}