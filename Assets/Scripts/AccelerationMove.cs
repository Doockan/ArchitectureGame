using UnityEngine;

internal sealed class AccelerationMove : MoveTransform
{
    private readonly float _acceleration;

    public AccelerationMove(Transform transform, float speed, float accelerationMove) : base(transform, speed)
    {
        _acceleration = accelerationMove;
    }

    public void AddAcceleration()
    {
        Speed += _acceleration;
    }

    public void RemoveAcceleration()
    {
        Speed -= _acceleration;
    }
}

