using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlaster : MonoBehaviour
{
    [SerializeField] float _bombRadius;
    [SerializeField] int _damage;
    [SerializeField] Animator _animator;

    public void Boom()
    {
        Collider[] hits = Physics.OverlapSphere(gameObject.transform.position, _bombRadius);

        foreach (Collider c in hits)
        {
            if (c.transform.TryGetComponent<IHaveHealth>(out IHaveHealth health))
            {
                health.Impact(_damage);
            }
        }

        _animator.SetTrigger("Boom");

        Destroy(gameObject, 0.5f);
    }

}
