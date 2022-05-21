namespace Asteroids.Interface
{
    public interface IMove
    {
        void AddForceForward(float force);
        void AddAcceleration(float force);
    }
}