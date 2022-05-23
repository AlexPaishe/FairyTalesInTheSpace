using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LeshiyMove : Enemy, ITriggerMove
{
    [SerializeField] private float _speed;
    private Transform _player;
    private bool _isIddle = true;
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
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.1f);
        if(Death == false)
        {
            Agent.destination = _player.position;
            StartCoroutine(Move());
        }
    }
}
