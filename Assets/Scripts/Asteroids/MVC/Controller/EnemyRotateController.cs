using Asteroids.MVC.Interface;
using UnityEngine;

public class EnemyRotateController : IExecute
{
    private readonly IRotate _rotate;
    private readonly Transform _target;

    public EnemyRotateController(IRotate rotate, Transform target)
    {
        _rotate = rotate;
        _target = target;
    }
    public void Execute(float deltaTime)
    {
        _rotate.Rotate(_target.position);
    }
}