using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViyMove : Enemy, ITriggerMove
{
    public bool IsAttack { get; set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _maxTimeWaitAttack;
    [SerializeField] private ViyAttack _viyAttack;

    private Transform _player;
    private bool _isIddle = true;
    private bool _isAlart = false;
    private GameObject _trigger;
    private Coroutine _moveCoroutine;
    private WaitForSeconds _waitForSeconds;
    private float _maxSpeed;

    void Start()
    {
        Agent.destination = transform.position;
        _maxSpeed = _speed;
        DoorOpen = true;
        _waitForSeconds = new WaitForSeconds(0.1f);
        Events = FindObjectOfType<Events>();
    }

    private void Update()
    {
        //Anima.SetFloat("Speed", _speed/_maxSpeed);
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
        yield return new WaitForSeconds(1);
        do
        {
            if (Death == false)
            {
                if (DoorOpen == true)
                {
                    CheckAlart();

                    if (IsAttack == false)
                    {
                        if (Vector3.Distance(_player.position, transform.position) < _attackDistance)
                        {
                            StartCoroutine(CounterAttack());
                            IsAttack = true;
                        }
                        else
                        {
                            MoveToPlayer();
                        }
                    }
                }

                else
                {
                    CheckDoor();
                }
            }
            else
            {
                Dead();
            }

            yield return _waitForSeconds;

        } while (true);
    }

    private IEnumerator CounterAttack()
    {
        float counter = 0;
        do
        {
            MoveToPlayer();
            counter += 0.1f;
            yield return _waitForSeconds;
        } while (counter < _maxTimeWaitAttack);

        Agent.speed = 0;
        _viyAttack.Attack();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<DoorOpenTrigger>(out DoorOpenTrigger door))
        {
            DoorOpen = false;
            _trigger = door.gameObject;
        }
    }

    private void CheckAlart()
    {
        if (_isAlart == false)
        {
            _isAlart = true;
            Sounds.SoundVaroation(1);
        }
    }

    private void CheckDoor()
    {
        if (_trigger.activeSelf == false)
        {
            DoorOpen = true;
        }
    }
    private void MoveToPlayer()
    {
        if (Vector3.Distance(_player.position, transform.position) > Agent.stoppingDistance)
        {
            Anima.SetFloat("Speed", 1);
        }
        else
        {
            Anima.SetFloat("Speed", 0);
        }
        Agent.speed = _speed;
        Agent.destination = _player.position;
    }

    private void Dead()
    {
        Collider.enabled = false;
        _viyAttack.StopLight();
        Anima.SetTrigger("Dead");
        Agent.speed = 0;
        StopCoroutine(_moveCoroutine);
    }

    private void OnDisable()
    {
        if (_moveCoroutine != null)
        {
            StopCoroutine(_moveCoroutine);
        }
    }
}
