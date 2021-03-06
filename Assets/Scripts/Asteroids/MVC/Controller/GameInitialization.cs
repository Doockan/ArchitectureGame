using Asteroids.MVC.Enemy;
using Asteroids.MVC.Model;
using Asteroids.MVC.Player;
using UnityEngine;

namespace Asteroids.MVC.Controller
{
    internal class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data.Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            
            var playerModel = new PlayerModel(data.Player.Sprite, data.Player.Speed, data.Player.Position, data.Player.Name);
            var playerFactory = new PlayerFactory(playerModel);
            var playerInitialization = new PlayerInitialization(playerFactory, playerModel.Position);

            var enemyFactory = new EnemyFactory(data.Enemy);
            var enemyInitialization = new EnemyInitialization(enemyFactory);

            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(enemyInitialization);

            controllers.Add(new InputController(inputInitialization.GetInput()));

            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), playerModel));
            
            controllers.Add(new EnemyMoveController(enemyInitialization.GetMoveEnemies(),playerInitialization.GetPlayer()));
            controllers.Add(new EnemyRotateController(enemyInitialization.GetRotateEnemies(), playerInitialization.GetPlayer()));
        }
    }
}