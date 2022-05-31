using System.IO;
using UnityEngine;

namespace Asteroids.MVC.Data
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public class Data: ScriptableObject
    {
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _playerDataPath;

        private EnemyData _enemy;
        private PlayerData _player;
        
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

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}