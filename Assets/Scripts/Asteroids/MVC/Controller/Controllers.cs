using System.Collections.Generic;
using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Controller
{
    internal class Controllers : IInitialization, IExecute, ICleanup
    {
        private readonly List<IInitialization> _initializaControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializaControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializaController)
            {
                _initializaControllers.Add(initializaController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        public void Initialization()
        {
            for (int i = 0; i < _initializaControllers.Count; ++i)
            {
                _initializaControllers[i].Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executeControllers.Count; ++i)
            {
                _executeControllers[i].Execute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (int i = 0; i < _cleanupControllers.Count; i++)
            {
                _cleanupControllers[i].Cleanup();
            }
        }
    }
}