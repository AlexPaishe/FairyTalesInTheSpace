using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletEdit _edit;

    private WaitForSeconds _liveTime;
    private Rigidbody _rigidbody;
    private float _currentSpeed;

    private void Awake()
    {
        _liveTime = new WaitForSeconds(_edit.liveTime);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _rigidbody.velocity = Vector3.zero;
        StartCoroutine(LiveCounter());
        _currentSpeed = _edit.speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.forward * _currentSpeed * 1);
        _currentSpeed -= 0.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
        {
            bulletReaction.Reaction(_edit.bulletType, collision.contacts[0].point);

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

