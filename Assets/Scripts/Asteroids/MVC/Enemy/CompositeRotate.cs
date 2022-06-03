using System.Collections.Generic;
using Asteroids.MVC.Interface;
using UnityEngine;

public class CompositeRotate : IRotate
{
    private List<IRotate> _rotates = new List<IRotate>();

    public void AddUnit(IRotate unit)
    {
        _rotates.Add(unit);
    }

    public void RemoveUnit(IRotate unit)
    {
        _rotates.Remove(unit);
    }

    public void Rotate(Vector3 point)
    {
        for (int i = 0; i < _rotates.Count; i++)
        {
            _rotates[i].Rotate(point);
        }
    }
}