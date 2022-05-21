using Asteroids.Interface;
using UnityEngine;

namespace Asteroids
{
    public class Mouse : IMouse
    {
        public Vector3 DirectionFromShip(Camera camera, Vector3 ship)
        {
            Vector3 direction = Input.mousePosition - camera.WorldToScreenPoint(ship);
            return direction;
        }
    }
}