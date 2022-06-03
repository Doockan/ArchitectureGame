using System.Collections.Generic;
using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Controller
{
    internal class Controllers : IInitialization, IExecute, ICleanup
    {
        private readonly List<IInitialization> _initializaControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ICleanup> _cleanupControllers;
        private readonly List<IFixedExecute> _fixedExecutesControllers;

        internal Controllers()
        {
            _initializaControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _cleanupControllers = new List<ICleanup>();
            _fixedExecutesControllers = new List<IFixedExecute>();
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

            if (controller is IFixedExecute fixedExecuteController)
            {
                _fixedExecutesControllers.Add(fixedExecuteController);
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

        public void FixedExecute(float deltaTime)
        {
            for (int i = 0; i < _fixedExecutesControllers.Count; i++)
            {
                _fixedExecutesControllers[i].FixedExecute(deltaTime);
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