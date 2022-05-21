using Asteroids.Interface;
using UnityEngine;

namespace Asteroids.Object_Pool
{
    public class Rockets : Ammunition, IDamageDealer
    {
        public float Damage { get; set; }
        
        private Rigidbody2D _rigidbody2D;
        private Transform _rotPool;


        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Damage = 10f;
        }

        public override void AddForce()
        {
            _rigidbody2D.AddForce(transform.up * 500f);
        }

        private void OnCollisionEnter2D()
        {
            ReturnToPool();
        }

        private void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

        private Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameTable.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }
    }
}