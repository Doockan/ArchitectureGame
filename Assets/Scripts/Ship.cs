using UnityEngine;

internal sealed class Ship : IMove, IRotation
{
    private readonly IMove _moveImplementation;
    private readonly IRotation _rotationImplementaion;
    public float Speed => _moveImplementation.Speed;

    public Ship(IMove moveImplementation, IRotation rotationImplementation)
    {
        _moveImplementation = moveImplementation;
        _rotationImplementaion = rotationImplementation;
    }
    public void Move(float horizontal, float vertical, float deltaTime)
    {
        _moveImplementation.Move(horizontal, vertical, deltaTime);
    }

    public void Rotation(Vector3 direction)
    {
        _rotationImplementaion.Rotation(direction);
    }

    public void AddAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.AddAcceleration();
        }
    }

    public void RemoveAcceleration()
    {
        if (_moveImplementation is AccelerationMove accelerationMove)
        {
            accelerationMove.RemoveAcceleration();
        }
    }
}