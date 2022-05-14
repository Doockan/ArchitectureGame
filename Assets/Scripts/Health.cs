public class Health : IHealth
{
    public float HealthPoint { get; private set; }
    
    public Health(float maxHealth)
    {
        HealthPoint = maxHealth;
    }

    public void Hit(float damage)
    {
        if (HealthPoint >= 0)
        {
            HealthPoint -= damage;    
        }
    }
}