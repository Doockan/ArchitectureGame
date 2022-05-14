using System.Collections;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private float radius;
    [SerializeField] private float force;
    
    
    private IEnumerator _lifeTime;

    private void Start()
    {
        _lifeTime = LifeTime(lifeTime);
        StartCoroutine(_lifeTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        Explode();
    }


    private IEnumerator LifeTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] overlappedColliders = Physics.OverlapSphere(transform.position, radius);

        for (int i = 0; i < overlappedColliders.Length; i++)
        {
            Rigidbody2D rigidbody = overlappedColliders[i].GetComponent<Rigidbody2D>();
            
            if (rigidbody)
            {
                //rigidbody.AddForce((rigidbody.position - transform.position) * force);
            }
        }
        Destroy(gameObject);
    }
}