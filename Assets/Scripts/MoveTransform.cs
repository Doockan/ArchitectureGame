using UnityEngine;
using DG.Tweening;

public class MoveTransform : IMove
{
    private Transform _transform;

    public MoveTransform(Transform transform)
    {
        _transform = transform;
    }
    
    public void Move(Vector2 axis, float maxSpeed, float deltaTime)
    {
        throw new System.NotImplementedException();
    }
}