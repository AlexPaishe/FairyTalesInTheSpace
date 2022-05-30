using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuleAttack : MonoBehaviour
{
    [SerializeField] private GuleMove _gule;
    [SerializeField] private Transform _guleAttack;
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _bullet;
    private Transform _player;

    public void GuleAttackEnd()
    {
        _guleAttack.localRotation = Quaternion.Euler(Vector3.zero);
        _gule.AgentSpeed();
        StartCoroutine(_gule.StartAttack());
    }

    public void BeginAttack()
    {
        _player = _gule.PlayerAttack();
        Vector3 pos = _player.position;
        pos.y = _guleAttack.position.y;
        _guleAttack.LookAt(pos);
    }

    public void Attack()
    {
        Vector3 pos = _player.position;
        pos.y = _point.position.y;
        _point.LookAt(pos);
        Instantiate(_bullet, _point.position, _point.rotation);
    }
}
