using UnityEngine;

public class RocketModeel : IRocketModel
{
    public Sprite Sprite { get; }
    public string Name { get; }
    public float Speed { get; }
    public float Damage { get; }

    public RocketModeel(Sprite sprite, string name, float speed, float damage)
    {
        Sprite = sprite;
        Name = name;
        Speed = speed;
        Damage = damage;
    }
}