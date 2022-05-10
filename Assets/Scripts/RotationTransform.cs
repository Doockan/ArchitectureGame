using UnityEngine;

public class RotationTransform : IRotation
{
    private Transform _transform;

    public RotationTransform(Transform transform)
    {
        _transform = transform;
    }

    public void Rotation(Vector3 direction)
    {
        _transform.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}