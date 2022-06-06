using Asteroids.MVC.Enemy;
using Asteroids.MVC.Model;
using Asteroids.MVC.Player;
using Asteroids.MVC.Prototype;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    internal class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data.Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            
            var playerModel = new PlayerModel(data.Player.PlayerPrefab, data.Player.Speed, data.Player.RotateSpeed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);

            var rocketModel = new RocketModeel(data.Rocket.Sprite, data.Rocket.Name, data.Rocket.Speed, data.Rocket.Damage);

            var ammunitionFactory = new AmmunitionFactory(rocketModel);
            var ammunitionPool = new AmmunitionPool(ammunitionFactory, 15);

            var enemyFactory = new EnemyFactory(data.Enemy);
            var enemyInitialization = new EnemyInitialization(enemyFactory);
            //var enemyinitialization2 = enemyInitialization.DeepCopy();

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);

            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MousController(inputInitialization.GetMousPosition()));
            controllers.Add(new FireController(ammunitionPool, playerInitialization.GetPlayer()));

            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel));
            controllers.Add(new RotateController(inputInitialization.GetMousPosition(),playerInitialization.GetPlayer(), camera, playerModel));
            
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(),playerInitialization.GetPlayer()));
            controllers.Add(new EnemyRotateController(enemyInitialization.GetRotateEnemies(), playerInitialization.GetPlayer()));
            
            //controllers.Add(new EnemyMoveController(enemyinitialization2.GetMoveEnemies(),playerInitialization.GetPlayer()));
            //controllers.Add(new EnemyRotateController(enemyinitialization2.GetRotateEnemies(), playerInitialization.GetPlayer()));
            
            
        }
    }
}