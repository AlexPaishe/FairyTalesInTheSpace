using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuleMove : Enemy, ITriggerMove
{
    [SerializeField] private float _speed;
    //[SerializeField] private Transform _point;
    [SerializeField] private Transform _pointRot;
    [SerializeField] private LayerMask _layer;
    [SerializeField] private float _distance;
    private Transform _player;
    private Vector3 _target;
    private bool _isIddle = true;
    void Start()
    {
        Agent.speed = _speed;
        Agent.destination = transform.position;
        //_point.transform.parent = transform.parent;
        NewTarget();
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
        if (Death == false && transform.position != _target)
        {
            Agent.destination = _target;
            StartCoroutine(Move());
        }
        else if (Death == false && transform.position == _target)
        {
            Debug.Log("y");
            NewTarget();
            Agent.destination = _target;
            StartCoroutine(Move());
        }
    }

    private void NewTarget()
    {
        int rand = Random.Range(0, 360);
        _pointRot.Rotate(0, rand, 0);
        Ray ray = new Ray(_pointRot.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _layer))
        {
            Vector3 pos = hit.point;
            pos.y = transform.position.y;
            _target = pos;
            //_point.position = _target;
            Debug.Log(hit.point);
            Debug.Log(_target);
        }
        else
        {
            Vector3 pos = _pointRot.position + (_pointRot.forward * _distance);
            pos.y = transform.position.y;
            _target = pos;
            //_point.position = _target;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent<BulletReaction>(out BulletReaction point))
        {
            NewTarget();
        }
    }
}
