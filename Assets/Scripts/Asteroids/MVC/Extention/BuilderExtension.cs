using UnityEngine;

namespace Asteroids.MVC.Extention
{
    public static partial class BuilderExtension
    {
        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }
        
        public static GameObject AddPolygonCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<PolygonCollider2D>();
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravity)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.gravityScale = gravity;
            return gameObject;
        }
        
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }
    }
}