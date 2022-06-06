using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeshiyMove : Enemy, ITriggerMove
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _stopDistance;
    [SerializeField] private LeshiyAttack _leshiy;
    private Transform _player;
    private bool _isIddle = true;
    private bool _isAlart = false;
    private GameObject _trigger;
    public bool IsAttack { get; set; }

    void Start()
    {
        Agent.speed = _speed;
        Agent.destination = transform.position;
        DoorOpen = true;
    }

    public void StartMove(Transform trans)
    {
        if (_isIddle == true)
        {
            _player = trans;
            _isIddle = false;
           StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.1f);
        if(Death == false)
        {
            if (Base.Death == false && DoorOpen == true)
            {
                if (_isAlart == false)
                {
                    _isAlart = true;
                    Sounds.SoundVaroation(1);
                }
                Agent.destination = _player.position;
                if (Vector3.Distance(_player.position, transform.position) < _attackDistance && IsAttack == false)
                {
                    IsAttack = true;
                    _leshiy.Attack();
                }
                if (Vector3.Distance(_player.position, transform.position) < _stopDistance)
                {
                    Anima.SetFloat("Speed", 0);
                }
                else
                {
                    Anima.SetFloat("Speed", 1);
                }
                StartCoroutine(Move());
            }
            else if(Base.Death == true)
            {
                Anima.SetFloat("Speed", 0);
                Agent.speed = 0;
            }
            else if(DoorOpen == false)
            {
                if(_trigger.activeSelf == false)
                {
                    DoorOpen = true;
                }
                StartCoroutine(Move());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<DoorOpenTrigger>(out DoorOpenTrigger door))
        {
            DoorOpen = false;
            _trigger = door.gameObject;
        }
    }
}
