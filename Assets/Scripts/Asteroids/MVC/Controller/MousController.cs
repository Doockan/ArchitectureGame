using Asteroids.MVC.Interface;

namespace Asteroids.MVC.Controller
{
    public class MousController : IExecute
    {
        private readonly IUserMousPosition _horizontal;
        private readonly IUserMousPosition _vertical;

        public MousController((IUserMousPosition positionHorizontal, IUserMousPosition positionVertical) position)
        {
            _horizontal = position.positionHorizontal;
            _vertical = position.positionVertical;
        }
        
        public void Execute(float deltaTime)
        {
            _horizontal.GetPosition();
            _vertical.GetPosition();
        }
    }
}