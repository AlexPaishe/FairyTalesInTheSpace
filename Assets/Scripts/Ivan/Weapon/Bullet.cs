using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletEdit _edit;

    [SerializeField] private float _speed;
    [SerializeField] private float _liveTime;
    [SerializeField] private int _damage;
    [SerializeField] private float _force;

    private void Start()
    {
        Destroy(gameObject, _edit.liveTime);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _edit.speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<IHaveHealth>(out IHaveHealth iHaveHeaith))
        {
            iHaveHeaith.Impact(_edit.damage);
            if(collision.transform.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(transform.forward * _edit.force, ForceMode.Impulse);
            }
        }

        Destroy(gameObject);
    }
}

