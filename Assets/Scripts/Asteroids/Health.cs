using Asteroids.Interface;
using UnityEngine;

namespace Asteroids
{
    public class Health : IHealth
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; private set; }

        public Health(float maxHealth, float currentHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;
        }

        public void ChangeCurrentHealth(float hp)
        {
            CurrentHealth -= hp;
            Debug.Log($"Получил {hp} урона");
        }
    }
}