using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Izlar : Weapon
{
    [SerializeField] private GameObject _secondIzlar;
    [SerializeField] private Transform _rightShootPoint;
    [SerializeField] private Transform _leftShootPoint;
    [SerializeField] private IzlarEdit _edit;
    [SerializeField] private GameObject _bullet;

    public override float TimeReadyFastAttack => _edit.waitJerkTime;
    public override int DamageFastAttack => _edit.jerkDamage;
    public override float ForceFastAttack => _edit.jerkForce;

    private PlayerAnimation _animation;
    private Events _events;
    private Rigidbody _playerRB;
    private Coroutine _shoot;
    private Transform _legs;
    private WaitForSeconds _shootFrequency;
    private WaitForSeconds _changeGunsFrequency;
    private Queue<GameObject> _bulletsPool;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _events = base.Events;
        _playerRB = base.PlayerParts.Rigidbody;
        _secondIzlar.transform.parent = base.PlayerParts.LeftHandPoint;
        _secondIzlar.transform.localPosition = Vector3.zero;
        _secondIzlar.transform.localRotation = Quaternion.identity;
        _legs = base.PlayerParts.Legs;
        _shootFrequency = new WaitForSeconds(_edit.shootFrequency);
        _changeGunsFrequency = new WaitForSeconds(_edit.changeGunsFrequency);

        _bulletsPool = FillBulletsPull(_edit.bulletReservCount);
    }

    public override void StartShoot()
    {
        _animation.StartShoot(true);
        _shoot = StartCoroutine(Shoot());
    }

    public override void StopShoot()
    {
        _animation.StartShoot(false);
        StopCoroutine(_shoot);
    }

    public override void FastAttak()
    {
        _animation.Jerk();
        _playerRB.AddForce(_legs.transform.forward * _edit.jerkForce, ForceMode.Impulse);
        _events.Jerk(true);

        StartCoroutine(WaitJerkReady());
    }

    private IEnumerator WaitJerkReady()
    {
        yield return new WaitForSeconds(0.1f);
        _events.Jerk(false);                                //Перенести вызов метода в конец анимации рывка
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            _animation.Shoot(true);

            BulletInstance(_leftShootPoint);

            yield return _shootFrequency;

            _animation.Shoot(false);

            BulletInstance(_rightShootPoint);

            yield return _changeGunsFrequency;
        }
    }

    private Queue<GameObject> FillBulletsPull(int bulletReservCount)
    {
        Queue<GameObject> queue = new Queue<GameObject>();

        GameObject Pool = new GameObject("BulletsPool");

        for (int i = 0; i < bulletReservCount; i++)
        {
            queue.Enqueue(Instantiate(_bullet, Pool.transform));
        }

        return queue;
    }

    private void BulletInstance(Transform point)
    {
        GameObject bullet = _bulletsPool.Dequeue();
        bullet.transform.position = point.position;
        bullet.transform.rotation = point.rotation;
        bullet.SetActive(true);
        _bulletsPool.Enqueue(bullet);
    }
}