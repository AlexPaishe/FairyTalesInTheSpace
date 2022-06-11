using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private BlasterEdit _edit;
    [SerializeField] private Light _light;
    [SerializeField] private float _aimingSpeed;
    [SerializeField] private Sound _sound;

    public override int Index => 2;
    public override float TimeReadyFastAttack => _edit.timeCharging;

    private PlayerAnimation _animation;
    private Transform _torso;
    private Coroutine _shootCoroutine;
    private WaitForSeconds _coroutineTick;
    private float _angel = 0;
    private float _addedAngel;
    private PlayerRotation _rotation;
    private PlayerMovement _movement;
    private float _defaultSpeed;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _torso = base.PlayerParts.Torso;
        _coroutineTick = new WaitForSeconds(0.05f);
        _addedAngel = _edit.timeCharging / _edit.angelAttack * 100;
        _light.spotAngle = 0;
        _rotation = base.PlayerParts.Father.GetComponent<PlayerRotation>();
        _movement = base.PlayerParts.Father.GetComponent<PlayerMovement>();
        _defaultSpeed = _movement.Speed;
    }

    public override void StartShoot()
    {
        _shootCoroutine = StartCoroutine(ShootFoward());
        _movement.Speed = _aimingSpeed;

        _sound.SoundPlay(0);
    }

    private IEnumerator ShootFoward()
    {
        _angel = 0;

        do
        {
            _angel += _addedAngel;
            _light.spotAngle = _angel;

            yield return _coroutineTick;

        } while (_angel < _edit.angelAttack);
    }

    public override void StopShoot()
    {
        _rotation.BlockedRotate = true;

        if( _shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
        }
        _animation.BlasterShootFoward();
        StartCoroutine(Shoot());

        _movement.Speed = _defaultSpeed;

        _sound.SoundPlay(1);
    }

    private IEnumerator Shoot()
    {
        float delay = 0.1f;

        Color defaultColor = _light.color;

        while (delay < 1)
        {
            Color colour = new Color(_light.color.r + 0.5f, _light.color.g + 0.5f, _light.color.b + 0.5f);
            _light.color = colour;

            delay++;
            yield return new WaitForSeconds(delay / 4);
        }

        _light.color = defaultColor;

        _light.spotAngle = 0;

        DealDamage();

        _rotation.BlockedRotate = false;
    }

    private void Update()
    {
        Debug.DrawRay(_torso.position, _torso.forward);
    }

    private void DealDamage()
    {
        RaycastHit[] hits = Physics.SphereCastAll(_torso.position, 5, _torso.forward, _edit.Shootdistanse);

        foreach(RaycastHit hit in hits)
        {
            if (Vector3.Angle(_torso.forward, hit.transform.position - _torso.position) < _angel / 2)
            {
                if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    Ray ray = new Ray(_torso.position + Vector3.up,  enemy.transform.position + Vector3.up - _torso.position + Vector3.up);

                    RaycastHit[] obstacleHits = Physics.RaycastAll(ray, Vector3.Distance(_torso.position, hit.transform.position));

                    bool isObstacle = false;

                    foreach(RaycastHit obstacle in obstacleHits)
                    {
                        if (obstacle.transform.CompareTag("Obstacle"))
                        {
                            isObstacle = true;
                        }
                    }

                    if (isObstacle == false)
                    {
                        enemy.Impact(2 + (int)((float)_edit.shootDamage * _angel / _edit.angelAttack) - 2);
                    }
                }
            }
        }
    }

    public override void FastAttak()
    {
        _animation.BlasterShootUp();
    }
}
