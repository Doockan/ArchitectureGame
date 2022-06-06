using Asteroids.MVC.Data;
using Asteroids.MVC.Player;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
public sealed class PlayerData : ScriptableObject, IUnit
{
    public PlayerProvider PlayerPrefab;
    [SerializeField] private string _name;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector2Int _position;

    public float Speed => _speed;
    public float RotateSpeed => _rotateSpeed;
    public Vector2Int Position => _position;
    public string Name => _name;
}