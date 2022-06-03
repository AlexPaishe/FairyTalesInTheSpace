using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _secondPortal;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private AudioSource _audioSource;

    private bool _movementAllowed;
    private Coroutine _delayedMove;

    private void Start()
    {
        _movementAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movementAllowed == true)
        {
            if (other.transform.GetComponent<Player>())
            {
                _delayedMove = StartCoroutine(DelayedMove(other.transform));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            if(_delayedMove != null)
            {
                StopCoroutine(_delayedMove);
            }
        }
    }

    public void StartCharging()
    {
        _audioSource.clip = _clips[1];
        _audioSource.Play();
        StartCoroutine(Charging());
    }

    private IEnumerator DelayedMove(Transform player)
    {
        yield return new WaitForSeconds(0.5f);
        _audioSource.clip = _clips[0];
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        _secondPortal.StartCharging();
        player.position = _secondPortal.transform.position;
    }

    private IEnumerator Charging()
    {
        _movementAllowed = false;
        yield return new WaitForSeconds(5);
        _movementAllowed = true;
        _audioSource.clip = _clips[2];
        _audioSource.Play();
    }
}
