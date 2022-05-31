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
    public bool IsAttack { get; set; }

    void Start()
    {
        Agent.speed = _speed;
        Agent.destination = transform.position;
    }

    public void StartMove(Transform trans)
    {
        if (_isIddle == true)
        {
            _player = trans;
            _isIddle = false;
            Anima.SetFloat("Speed", 1);
            Sounds.SoundVaroation(1);
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.03f);
        if(Death == false)
        {
            Agent.destination = _player.position;
            if(Vector3.Distance(_player.position, transform.position) < _attackDistance && IsAttack == false)
            {
                IsAttack = true;
                _leshiy.Attack();
            }
            if(Vector3.Distance(_player.position, transform.position) < _stopDistance)
            {
                Anima.SetFloat("Speed", 0);
            }
            else
            {
                Anima.SetFloat("Speed", 1);
            }
            StartCoroutine(Move());
        }
    }
}
