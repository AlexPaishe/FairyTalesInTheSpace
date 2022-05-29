using System.Collections.Generic;
using UnityEngine;

public class BulletReaction : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    [SerializeField] private ParticleSystem[] _effectsPlayerBullet;
    [SerializeField] private ParticleSystem[] _effectsGuleBullet;

    [SerializeField] private int _effectReservcount;

    private Queue<ParticleSystem> _particlesPlayerPool;
    private Queue<ParticleSystem> _particlesGulePool;

    private void Start()
    {
        _particlesPlayerPool = FillEffectPull(_effectsPlayerBullet , _effectReservcount);
        _particlesGulePool = FillEffectPull(_effectsGuleBullet , _effectReservcount);
    }

    public void Reaction(BulletType bulletType, Vector3 point)
    {
        if (_audioClips.Length > 0)
        {
            _audioSource.clip = _audioClips[Random.Range(0, _audioClips.Length)];
            _audioSource.Play();
        }

        if (bulletType == BulletType.PlayerBullet)
        {
            PlayEffect(_particlesPlayerPool, point);
        }

        if (bulletType == BulletType.GuleBullet)
        {
            PlayEffect(_particlesGulePool, point);
        }
    }

    private Queue<ParticleSystem> FillEffectPull(ParticleSystem[] effects , int effectReservCount)
    {
        Queue<ParticleSystem> queue = new Queue<ParticleSystem>();

        if (effects.Length > 0)
        {
            GameObject Pool = new GameObject("EffectsPool");

            for (int i = 0; i < effectReservCount; i++)
            {
                queue.Enqueue(Instantiate(effects[Random.Range(0, effects.Length)], Pool.transform));
            }
        }
        
        return queue;
    }

    private void PlayEffect(Queue<ParticleSystem> effects, Vector3 point)
    {
        if(effects.Count > 0)
        {
            ParticleSystem effect = effects.Dequeue();
            effect.gameObject.transform.position = point;
            effect.Play();
            effects.Enqueue(effect);
        }
    }
}
