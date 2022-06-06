using UnityEngine;

public interface IRocketModel
{
    public Sprite Sprite { get; }
    public string Name { get; }
    public float Speed { get; }
    public float Damage { get; }
}