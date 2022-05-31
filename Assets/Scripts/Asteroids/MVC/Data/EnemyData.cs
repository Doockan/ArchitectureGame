using System;
using System.Collections.Generic;
using System.Linq;
using Asteroids.MVC.Enemy;
using UnityEngine;

namespace Asteroids.MVC.Data
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "Data/Unit/EnemySettings")]
    public class EnemyData : ScriptableObject
    {
        [Serializable]
        private struct EnemyInfo
        {
            public EnemyType Type;
            public EnemyProvider EnemyPrefab;
        }

        [SerializeField] private List<EnemyInfo> _enemyInfos;

        public EnemyProvider GetEnemy(EnemyType type)
        {
            var enemyInfo = _enemyInfos.FirstOrDefault(info => info.Type == type);
            if (enemyInfo.EnemyPrefab == null)
            {
                throw new InvalidOperationException($"Enemy type {type} not found");
            }

            return enemyInfo.EnemyPrefab;
        }
    }
}