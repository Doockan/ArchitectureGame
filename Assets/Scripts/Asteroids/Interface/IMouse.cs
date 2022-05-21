using UnityEngine;

namespace Asteroids.Interface
{
    public interface IMouse
    {
        Vector3 DirectionFromShip(Camera camera, Vector3 ship);
    }
}