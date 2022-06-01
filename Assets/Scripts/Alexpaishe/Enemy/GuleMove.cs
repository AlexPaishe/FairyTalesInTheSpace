using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuleMove : Enemy, ITriggerMove
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _point;
    [SerializeField] private Transform _pointRot;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _minTimeAttack;
    [SerializeField] private float _maxTimeAttack;
    private Transform _player;
    private Vector3 _target;
    private bool _isIddle = true;
    void Start()
    {
        Agent.speed = _speed;
        Agent.destination = transform.position;
        _point.transform.parent = transform.parent;
        NewTarget();
        DoorOpen = true;
    }

    public void StartMove(Transform trans)
    {
        if (_isIddle == true)
        {
            _player = trans;
            _isIddle = false;
            Anima.SetFloat("Speed", 1);
            StartCoroutine(Move());
            StartCoroutine(StartAttack());
        }
    }

    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0.1f);
        if (DoorOpen == true)
        {
            if (Death == false && Vector3.Distance(transform.position, _target) > _minDistance)
            {
                Agent.destination = _target;
                Anima.SetFloat("Speed", 1);
                StartCoroutine(Move());
            }
            else if (Death == false && Vector3.Distance(transform.position, _target) <= _minDistance)
            {
                NewTarget();
                Agent.destination = _target;
                Anima.SetFloat("Speed", 1);
                StartCoroutine(Move());
            }
        }
        else
        {
            StartCoroutine(Move());
            Anima.SetFloat("Speed", 0);
            DoorOpen = true;
        }
    }

    /// <summary>
    /// Реализация выбора нового таргета
    /// </summary>
    private void NewTarget()
    {
        int rand = Random.Range(0, 360);
        _pointRot.Rotate(0, rand, 0);
        Vector3 pose = _pointRot.position + (_pointRot.forward * _maxDistance);
        Ray ray = new Ray(_pointRot.position, Vector3.forward);
        RaycastHit hit;
        if(Physics.Linecast(_pointRot.position, pose, out hit, _layer))
        {
            Vector3 pos = hit.point;
            pos.y = transform.position.y;
            _target = pos;
            _point.position = _target;
        }
        else
        {
            Vector3 pos = _pointRot.position + (_pointRot.forward * _maxDistance);
            pos.y = transform.position.y;
            _target = pos;
            _point.position = _target;
        }
    }

    public IEnumerator StartAttack()
    {
        float rand = Random.Range(_minTimeAttack, _maxTimeAttack);
        yield return new WaitForSeconds(rand);
        if (Death == false)
        {
            Agent.speed = 0;
            if (Base.Death == false && DoorOpen == true)
            {
                Anima.SetTrigger("Attack");
            }
            else if(Base.Death == true)
            {
                Anima.SetFloat("Speed", 0);
            }
            else if(DoorOpen == false)
            {
                StartCoroutine(StartAttack());
            }
        }
    }

    public void AgentSpeed()
    {
        if (Death == false)
        {
            Agent.speed = _speed;
        }
    }

    public Transform PlayerAttack()
    {
        return _player;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<DoorOpenTrigger>(out DoorOpenTrigger door))
        {
            DoorOpen = false;
        }
    }
}
