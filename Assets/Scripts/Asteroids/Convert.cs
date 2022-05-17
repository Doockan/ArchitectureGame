using UnityEngine;

namespace Asteroids
{
    public static class Convert
    {
        public static Vector2 GetVector2(Vector3 vector3)
        {
            Vector2 vector2;
            vector2.x = vector3.x;
            vector2.y = vector3.z;
            return vector2;
        }
    }
}

