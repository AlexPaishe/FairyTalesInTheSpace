using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletEdit _edit;

    private WaitForSeconds _liveTime;

    private void Awake()
    {
        _liveTime = new WaitForSeconds(_edit.liveTime);
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

        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(LiveCounter());
    }

    private IEnumerator LiveCounter()
    {
        yield return _liveTime;
        gameObject.SetActive(false);
    }
}

