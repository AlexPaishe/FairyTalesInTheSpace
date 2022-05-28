using System.Collections.Generic;
using UnityEngine;

public class BulletReaction : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private int _effectReservcount;

    private Queue<ParticleSystem> _particlesPool;

    private void Start()
    {
        _particlesPool = FillEffectPull(_effectReservcount);
    }

    public void Reaction(Vector3 point)
    {
        _audioSource.Stop();
        _audioSource.Play();
        EffectPlay(point);
    }

    private Queue<ParticleSystem> FillEffectPull(int effectReservCount)
    {
        Queue<ParticleSystem> queue = new Queue<ParticleSystem>();

        GameObject Pool = new GameObject($"{gameObject.name} effect pool");

        for (int i = 0; i < effectReservCount; i++)
        {
            queue.Enqueue(Instantiate(_effect, Pool.transform));
        }

        return queue;
    }

    private void EffectPlay(Vector3 point)
    {
        ParticleSystem effect = _particlesPool.Dequeue();
        effect.gameObject.transform.position = point;
        effect.Play();
        _particlesPool.Enqueue(effect);
    }
}
