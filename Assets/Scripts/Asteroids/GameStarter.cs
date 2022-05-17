using System.Collections;
using Asteroids.Enemys;
using Asteroids.Interface;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            IEnemyFactory asteroidFactory = new AsteroidFactory();
            IEnemyFactory enemyShipFactory = new EnemyShipFactory();


            enemyShipFactory.Create(new Health(100, 100));
            asteroidFactory.Create(new Health(100, 100));
        }
    }
}