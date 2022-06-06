using Asteroids.MVC.Extention;
using Asteroids.Object_Pool;
using UnityEngine;

public class AmmunitionFactory : IAmmunitionFactory
{
    private readonly IRocketModel _rocketData;

    public AmmunitionFactory(IRocketModel rocketData)
    {
        _rocketData = rocketData;
    }


    public GameObject CreateAmmunition()
    {
        var rocket = new GameObject(_rocketData.Name).AddSprite(_rocketData.Sprite).AddPolygonCollider2D()
            .AddRigidbody2D(1f, 0f);
        return rocket;
    }

    public Rockets CreateRocket()
    {
        return  CreateAmmunition().AddComponent<Rockets>();
    }
}