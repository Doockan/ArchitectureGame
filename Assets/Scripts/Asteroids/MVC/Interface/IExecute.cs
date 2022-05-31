namespace Asteroids.MVC.Interface
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}