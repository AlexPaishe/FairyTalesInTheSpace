using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViyMove : Enemy, ITriggerMove
{
    public bool IsAttack { get; set; }

    [SerializeField] private float _attackDistance;
    [SerializeField] private ViyAttack _viyAttack;

    private Transform _player;
    private bool _isIddle = true;
    private bool _isAlart = false;
    private GameObject _trigger;
    private Coroutine _moveCoroutine;
    private WaitForSeconds _waitForSeconds;

    void Start()
    {
        Agent.destination = transform.position;
        DoorOpen = true;
        _waitForSeconds = new WaitForSeconds(0.1f);
    }

    public void StartMove(Transform trans)
    {

        if (_isIddle == true)
        {
            _player = trans;
            _isIddle = false;
            _moveCoroutine = StartCoroutine(Move());
        }
    }
    private IEnumerator Move()
    {
        do
        {
            if (Death == false)
            {
                if (DoorOpen == true)
                {
                    if (_isAlart == false)
                    {
                        _isAlart = true;
                        Sounds.SoundVaroation(1);
                    }
                    if (Vector3.Distance(_player.position, transform.position) < _attackDistance && IsAttack == false)
                    {
                        IsAttack = true;
                        _viyAttack.Attack();
                    }
                }
                else
                {
                    if (_trigger.activeSelf == false)
                    {
                        DoorOpen = true;
                    }
                }
            }
            else
            {
                Anima.SetTrigger("Dead");
                Agent.speed = 0;
                StopCoroutine(_moveCoroutine);
            }

            Agent.destination = _player.position;
            yield return _waitForSeconds;

        } while (true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpenTrigger>(out DoorOpenTrigger door))
        {
            DoorOpen = false;
            _trigger = door.gameObject;
        }
    }
}
