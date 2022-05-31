namespace Asteroids.MVC.Enemy
{
    public interface IEnemyFactory
    {
        IEnemy CreateEnemy(EnemyType type);
    }
}