using UnityEngine;

namespace Asteroids.MVC.Controller
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data.Data _data;
        private Controllers _controllers;

        private void Start()
        {
            _controllers = new Controllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}