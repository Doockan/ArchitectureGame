using Asteroids.MVC.Interface;
using Asteroids.MVC.UserInput;

namespace Asteroids.MVC.Controller
{
    public class InputInitialization : IInitialization
    {
        private IUserInputProxy _pcInputHorizontal;
        private IUserInputProxy _pcInputVertical;
        private readonly MousPositionHorizontal _mousPositionHorizontal;
        private readonly MousPositionVertical _mousPositionVertical;

        public InputInitialization()
        {
            _pcInputHorizontal = new PCInputHorizontal();
            _pcInputVertical = new PCInputVertical();
            _mousPositionHorizontal = new MousPositionHorizontal();
            _mousPositionVertical = new MousPositionVertical();
        }
    
        public void Initialization()
        {
        }

        public (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) GetInput()
        {
            (IUserInputProxy inputHorizontal, IUserInputProxy inputVertical)
                result = (_pcInputHorizontal, _pcInputVertical);
            return result;
        }

        public (IUserMousPosition positionHorizontal, IUserMousPosition positionVertical) GetMousPosition()
        {
            (IUserMousPosition positionHorizontal, IUserMousPosition positionVertical) result = (_mousPositionHorizontal, _mousPositionVertical);
            return result;
        }
        
    }
}

