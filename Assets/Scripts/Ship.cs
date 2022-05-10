using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bullet;

    private IMove _moveTransform;
    
    private IInputSystem _inputSystem;
    private IRotation _rotation;

    private void Awake()
    {
        _inputSystem = Game.InputSystem;
        _moveTransform = new MoveTransform(transform);
        //_rotation = new Rotation(transform);
    }

    private void Update()
    {
        _moveTransform.Move(_inputSystem.Axis, speed, Time.deltaTime);
    }
}