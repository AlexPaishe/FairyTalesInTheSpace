using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float _timeCharging;
    [SerializeField] private float _timeWaitingMovement;
    [SerializeField] private Portal _secondPortal;
    [SerializeField] private Sound _sound;

    private bool _movementAllowed;
    private WaitForSeconds _waitingCharging;
    private WaitForSeconds _waitingMovement;
    private Coroutine _delayedMove;

    private void Start()
    {
        _waitingCharging = new WaitForSeconds(_timeCharging);
        _waitingMovement = new WaitForSeconds(_timeWaitingMovement);
        _movementAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movementAllowed == true)
        {
            if (other.transform.GetComponent<Player>())
            {
                _delayedMove = StartCoroutine(DelayedMove(other.transform));
                _sound.SoundPlay(2);
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
            _sound.SoundStop();
        }
    }

    public void StartCharging()
    {
        StartCoroutine(Charging());
    }

    private IEnumerator DelayedMove(Transform player)
    {
        yield return _waitingMovement;

        player.position = _secondPortal.transform.position;
        _sound.SoundPlay(0);

        _secondPortal.StartCharging();
        StartCharging();
    }

    private IEnumerator Charging()
    {
        _movementAllowed = false;
        yield return _waitingCharging;
        _movementAllowed = true;
        _sound.SoundPlay(1);
    }
}
