using UnityEngine;

public interface IMove
{
    void Move(Vector2 axis, float maxSpeed, float deltaTime);
}