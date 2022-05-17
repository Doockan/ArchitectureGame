using Asteroids.Enemys;

namespace Asteroids.Interface
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}