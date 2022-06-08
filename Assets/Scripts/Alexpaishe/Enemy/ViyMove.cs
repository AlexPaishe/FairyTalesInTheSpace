using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViyMove : Enemy, ITriggerMove
{
    public bool IsAttack { get; set; }

    [SerializeField] private float _speed;
    [SerializeField] private float _attackDistance;
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

                    if (IsAttack == false)
                    {
                        if (Vector3.Distance(_player.position, transform.position) < _attackDistance)
                        {
                            Agent.speed = _speed;
                            //_viyAttack.Attack();

                        }
                        else
                        {
                            Agent.speed = _speed;
                        }
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
                Anima.SetFloat("Speed", 0);
                StopCoroutine(_moveCoroutine);
                Debug.Log("Dead");
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
