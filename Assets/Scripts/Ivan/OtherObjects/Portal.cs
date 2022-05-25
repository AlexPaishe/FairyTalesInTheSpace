using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _secondPortal;
    [SerializeField] private Transform _movePosition;
    [SerializeField] private float _timeCharging;

    private bool _movementAllowed;
    private WaitForSeconds _waitingCharging;
    private WaitForSeconds _waitingMovement;

    private void Start()
    {
        _waitingCharging = new WaitForSeconds(_timeCharging);
        _waitingMovement = new WaitForSeconds(1);
        _movementAllowed = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movementAllowed == true)
        {
            if (other.transform.TryGetComponent<PlayerParts>(out PlayerParts player))
            {
                StartCoroutine(DelayedMove(player));
            }
        }
    }

    public void StartCharging()
    {
        StartCoroutine(Charging());
    }

    private IEnumerator DelayedMove(PlayerParts player)
    {
        PlayerMovement  playerMovement = player.Father.GetComponent<PlayerMovement>();

        playerMovement.BanMovement(true);
        playerMovement.RestMovement();

        yield return _waitingMovement;

        _secondPortal.StartCharging();
        StartCharging();

        player.transform.position = _movePosition.position;
        player.Legs.rotation = _movePosition.rotation;
        playerMovement.BanMovement(false);
    }

    private IEnumerator Charging()
    {
        _movementAllowed = false;
        yield return _waitingCharging;
        _movementAllowed = true;
    }
}
