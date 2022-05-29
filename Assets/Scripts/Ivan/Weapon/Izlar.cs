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
    private Transform _torso;
    private WaitForSeconds _shootFrequency;
    private WaitForSeconds _changeGunsFrequency;
    private Queue<GameObject> _bulletsPool;
    private GameObject[] _playerGO;
    private Collider[] _playerColliders;
    private int _layerJerkValue;
    private int _layerDefaultValue;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _events = base.Events;
        _playerRB = base.PlayerParts.Rigidbody;
        _secondIzlar.transform.parent = base.PlayerParts.LeftHandPoint;
        _secondIzlar.transform.localPosition = Vector3.zero;
        _secondIzlar.transform.localRotation = Quaternion.identity;
        _legs = base.PlayerParts.Legs;
        _torso = base.PlayerParts.Torso;
        _shootFrequency = new WaitForSeconds(_edit.shootFrequency);
        _changeGunsFrequency = new WaitForSeconds(_edit.changeGunsFrequency);
        _playerColliders = base.PlayerParts.Father.transform.GetComponentsInChildren<Collider>();
        _playerGO = FillGO(_playerColliders);
        _layerJerkValue = LayerMask.NameToLayer("BulletEnemy");
        _layerDefaultValue = LayerMask.NameToLayer("Player");

        _bulletsPool = FillBulletsPull(_edit.bulletReservCount);
        _animation.WeaponChange(0);
    }

    public override void StartShoot()
    {
        _shoot = StartCoroutine(Shoot());
    }

    public override void StopShoot()
    {
        _animation.StartShoot(false);
        StopCoroutine(_shoot);
    }

    public override void FastAttak()
    {
        ChangeLayer(_playerGO, _layerJerkValue);
        _animation.Jerk();
        _playerRB.AddForce(_legs.transform.forward * _edit.jerkForce, ForceMode.Impulse);
        _events.Jerk(true);

        StartCoroutine(WaitJerkReady());
    }

    private IEnumerator WaitJerkReady()
    {
        yield return new WaitForSeconds(0.1f);
        _events.Jerk(false);                                //Перенести вызов метода в конец анимации рывка
        ChangeLayer(_playerGO, _layerDefaultValue);
    }

    private IEnumerator Shoot()
    {
        _animation.StartShoot(true);
        yield return _changeGunsFrequency;

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
        bullet.transform.rotation = _torso.rotation;
        bullet.SetActive(true);
        _bulletsPool.Enqueue(bullet);
    }

    private GameObject[] FillGO(Collider[] colliders)
    {
        GameObject[] gameObjects = new GameObject[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            gameObjects[i] = colliders[i].gameObject;
        }
        return gameObjects;
    }

    private void ChangeLayer(GameObject[] gameObjects, int layer)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.layer = layer;
        }
    }
}