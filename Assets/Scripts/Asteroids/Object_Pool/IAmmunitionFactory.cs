using Unity.VisualScripting;
using UnityEngine;

namespace Asteroids.Object_Pool
{
    public interface IAmmunitionFactory
    {
        GameObject CreateAmmunition();
        Rockets CreateRocket();
    }
}