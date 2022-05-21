using Asteroids.Interface;
using UnityEngine;

namespace Asteroids
{
    public class InputSystem : IInputSystem
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string Fire1 = "Fire1";

        public Vector2 Axis => new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        public bool IsAttackButtonUp() => Input.GetButtonUp(Fire1);

        public bool IsAccelerationButtonUp() => Input.GetKey(KeyCode.LeftShift);

        public bool IsForwardButtonUp() => Input.GetKey(KeyCode.W);
    }
}