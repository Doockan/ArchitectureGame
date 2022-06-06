using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.MVC.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    [Serializable]
    public class Data: ScriptableObject
    {
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _rocketDataPath;

        private EnemyData _enemy;
        private PlayerData _player;
        private RocketData _rocket;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine("Data", _playerDataPath));
                }

                return _player;
            }
        }

        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>(Path.Combine("Data", _enemyDataPath));
                }

                return _enemy;
            }
        }

        public RocketData Rocket
        {
            get
            {
                if (_rocket == null)
                {
                    _rocket = Load<RocketData>(Path.Combine("Data", _rocketDataPath));
                }

                return _rocket;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}