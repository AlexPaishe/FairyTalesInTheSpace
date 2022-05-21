using System.Collections;
using UnityEngine;

public class Izlar : Weapon
{
    [SerializeField] private GameObject _secondIzlar;
    [SerializeField] private Transform _rightShootPoint;
    [SerializeField] private Transform _leftShootPoint;
    [SerializeField] private IzlarEdit _edit;
    [SerializeField] private GameObject _firstBullet;
    [SerializeField] private GameObject _secondBullet;

    public override float TimeReadyFastAttack => _edit.waitJerkTime;
    public override int DamageFastAttack => _edit.jerkDamage;
    public override float ForceFastAttack => _edit.jerkForce;

    private PlayerAnimation _animation;
    private Events _events;
    private Rigidbody _playerRB;
    private Coroutine _shoot;
    private Transform _legs;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _events = base.Events;
        _playerRB = base.PlayerParts.Rigidbody;
        _secondIzlar.transform.parent = base.PlayerParts.LeftHandPoint;
        _secondIzlar.transform.localPosition = Vector3.zero;
        _secondIzlar.transform.localRotation = Quaternion.identity;
        _legs = base.PlayerParts.Legs;
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
            Instantiate(_firstBullet, _leftShootPoint.position, _leftShootPoint.rotation);
            yield return new WaitForSeconds(_edit.shootFrequency);

            _animation.Shoot(false);
            Instantiate(_secondBullet, _rightShootPoint.position, _rightShootPoint.rotation);
            yield return new WaitForSeconds(_edit.changeGunsFrequency);
        }
    }
}