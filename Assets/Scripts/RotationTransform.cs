﻿using UnityEngine;

public class RotationTransform : IRotation
{
    private Transform _transform;

    public RotationTransform(Transform transform)
    {
        _transform = transform;
    }

    public void Rotation(Vector3 direction)
    {
        var angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _transform.rotation = Quaternion.AngleAxis(angel - 90f,Vector3.forward);
    }
}