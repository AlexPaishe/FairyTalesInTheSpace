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

    private Events _events;
    private Transform _legs;
    private Rigidbody _playerRB;
    private Coroutine _shoot;

    private void Awake()
    {
        
    }

    private void Start()
    {
        _events = FindObjectOfType<Events>();
        _playerRB = FindObjectOfType<Player>().GetComponent<Rigidbody>();

        Transform leftHandPoint = FindObjectOfType<LeftHandPoint>().GetComponent<Transform>();
        _secondIzlar.transform.parent = leftHandPoint;
        _secondIzlar.transform.localPosition = Vector3.zero;
    }

    public override void StartShoot()
    {
        _shoot = StartCoroutine(Shoot());
    }

    public override void StopShoot()
    {
        StopCoroutine(_shoot);
    }

    public override void FastAttak()
    {
        _playerRB.AddForce(_playerRB.transform.forward * _edit.jerkForce, ForceMode.Impulse);
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
            Instantiate(_firstBullet, _leftShootPoint.position, _leftShootPoint.rotation);
            yield return new WaitForSeconds(_edit.shootFrequency);

            Instantiate(_secondBullet, _rightShootPoint.position, _rightShootPoint.rotation);
            yield return new WaitForSeconds(_edit.changeGunsFrequency);
        }
    }
}