using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletEdit _edit;

    private WaitForSeconds _liveTime;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _liveTime = new WaitForSeconds(_edit.liveTime);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.forward * _edit.speed, ForceMode.Impulse);
        StartCoroutine(LiveCounter());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
        {
            bulletReaction.Reaction(collision.contacts[0].point);

            if (collision.transform.TryGetComponent<IHaveHealth>(out IHaveHealth haveHealth))
            {
                haveHealth.Impact(_edit.damage);
            }
        }

        gameObject.SetActive(false);
    }

    private IEnumerator LiveCounter()
    {
        yield return _liveTime;
        gameObject.SetActive(false);
    }
}

