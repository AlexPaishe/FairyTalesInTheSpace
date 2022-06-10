using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlaster : MonoBehaviour
{
    [SerializeField] private float _bombRadius;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private Sound _sound;

    private void Awake()
    {
        _sound.SoundPlay(0);
    }

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

        _sound.SoundPlay(1);

        Destroy(gameObject, 0.5f);
    }

}
