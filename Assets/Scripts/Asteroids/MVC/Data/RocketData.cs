using Asteroids.MVC.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "RocketSettings", menuName = "Data/Unit/RocketSettings")]
public sealed class RocketData : ScriptableObject, IUnit
{
    public Sprite Sprite;
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    public string Name => _name;
    public float Speed => _speed;
    public float Damage => _damage;
}