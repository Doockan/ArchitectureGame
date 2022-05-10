using UnityEngine;

public interface IInputSystem
{
    Vector2 Axis { get;}
    bool IsAttackButtonUp();
    bool IsAccelerationButtonUp();
}