using UnityEngine;

public class BulletReaction : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ParticleSystem _effect;

    public void Reaction(Vector3 point)
    {
        _audioSource.Play();
        _effect.gameObject.transform.position = point;
        _effect.Play();
    }
}
