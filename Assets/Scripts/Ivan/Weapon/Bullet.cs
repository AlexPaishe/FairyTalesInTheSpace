using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletEdit _edit;

    private WaitForSeconds _liveTime;
    private Vector3 _lastPos;

    private void Awake()
    {
        _liveTime = new WaitForSeconds(_edit.liveTime);
        _lastPos = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _edit.speed * Time.deltaTime);

        RaycastHit hit;

        if (Physics.Linecast(_lastPos, transform.position, out hit))
        {
            if(hit.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
            {
                bulletReaction.Reaction(hit.point);

                if (hit.transform.TryGetComponent<IHaveHealth>(out IHaveHealth haveHealth))
                {
                    haveHealth.Impact(_edit.damage);
                }
            }
            
            gameObject.SetActive(false);
        }

        _lastPos = transform.position;
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

