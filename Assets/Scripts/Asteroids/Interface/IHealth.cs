namespace Asteroids.Interface
{
    public interface IHealth
    {
        float MaxHealth { get; }
        float CurrentHealth { get;}

        void ChangeCurrentHealth(float damage);
    }
}