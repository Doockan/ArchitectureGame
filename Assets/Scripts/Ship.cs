using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float force;
    [SerializeField] private Transform barrel;
    [SerializeField] private Rigidbody2D bullet;

    private Camera _camera;

    private IInputSystem _inputSystem;
    private IHealth _health;
    
    private IMove _moveSystem;
    private IRotation _rotationSystem;

    private void Awake()
    {
        _health = new Health(100);
        _camera = Camera.main;
        _inputSystem = new InputSystem();
        _moveSystem = new MoveTransform(transform, speed);
        _rotationSystem = new RotationTransform(transform);
    }

    private void Update()
    {
        var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
        
        _rotationSystem.Rotation(direction);
        _moveSystem.Move(_inputSystem.Axis.x, _inputSystem.Axis.y, Time.deltaTime);
        
        if (_inputSystem.IsAttackButtonUp())
        {
            Fire();
        }
    }

    public void Fire()
    {
        var temAmmunition = Instantiate(bullet, barrel.position, barrel.rotation);
        temAmmunition.AddForce(barrel.up * force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("PlayerMissile"))
        {
            if (_health.HealthPoint <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Damage 5");
                _health.Hit(5);
            }
        }
        
    }
}