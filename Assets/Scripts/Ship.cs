using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bullet;

    private Camera _camera;
    
    private IMove _moveSystem;
    
    private IInputSystem _inputSystem;
    private IRotation _rotationSystem;

    private void Awake()
    {
        _camera = Camera.main;
        _inputSystem = Game.InputSystem;
        _moveSystem = new MoveTransform(transform);
        _rotationSystem = new RotationTransform(transform);
    }

    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        direction.z = 0f;
        _rotationSystem.Rotation(direction);

        //_moveSystem.Move(_inputSystem.Axis, speed, Time.deltaTime);
    }
}