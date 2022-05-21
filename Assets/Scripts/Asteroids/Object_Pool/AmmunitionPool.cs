using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Object_Pool
{
    public class AmmunitionPool
    {
        private readonly Dictionary<string, HashSet<Ammunition>> _ammunitionPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public AmmunitionPool(int capacityPool)
        {
            _ammunitionPool = new Dictionary<string, HashSet<Ammunition>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameTable.POOL_AMMUNITION).transform;
            }
        }

        public Ammunition GetAmmunition(string type)
        {
            Ammunition result;
            switch (type)
            {
                case "Rockets":
                    result = GetRockets(GetListAmmunition(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Not included in the program");
            }

            return result;
        }

        private Ammunition GetRockets(HashSet<Ammunition> ammunitions)
        {
            var ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (ammunition == null)
            {
                var rockets = Resources.Load<Ammunition>("Ammunition/Rockets");
                for (int i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(rockets);
                    ReturnToPool(instantiate.transform);
                    ammunitions.Add(instantiate);
                }
            }

            ammunition = ammunitions.FirstOrDefault(a => !a.gameObject.activeSelf);
            return ammunition;
        }

        private HashSet<Ammunition> GetListAmmunition(string type)
        {
            return _ammunitionPool.ContainsKey(type)
                ? _ammunitionPool[type]
                : _ammunitionPool[type] = new HashSet<Ammunition>();
        }

        public void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }
    }
}