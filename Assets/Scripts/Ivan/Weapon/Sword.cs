using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Sword : Weapon
{
    [SerializeField] private SwordEdit _edit;
    [SerializeField] private SwordCollisionHandler _swordCollisionHandler;

    public override float TimeReadyFastAttack => _edit.waitCircleAttackTime;
    public override int Index => 1;

    private PlayerAnimation _animation;
    private Events _events;
    private Rigidbody _playerRB;
    private Transform _torso;
    private JerkDirection _jerkDirection;
    private Coroutine _jerkCharging;
    private bool _isJerk;
    private float _jerkDistance;
    private float _distanceOneTick;
    private WaitForSeconds _chargTick;
    private Vector3 _jerkStartPos;
    private Vector3 _jerkCurrentDirection;
    private Collider[] _playerColliders;
    private int _layerJerkValue;
    private int _layerDefaultValue;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _events = base.Events;
        _playerRB = base.PlayerParts.Rigidbody;
        _torso = base.PlayerParts.Torso;
        _jerkDirection = base.PlayerParts.JerkDirection;
        _chargTick = new WaitForSeconds(0.05f);
        _distanceOneTick = _edit.chargJerkTime / _edit.jerkMaxDistance;
        _layerJerkValue = LayerMask.NameToLayer("BulletEnemy");
        _layerDefaultValue = LayerMask.NameToLayer("Player");
        _playerColliders = new Collider[2];
        _playerColliders[0] = base.PlayerParts.Father.GetComponent<Collider>();
        _playerColliders[1] = _swordCollisionHandler.transform.GetComponent<Collider>();
    }

    public override void StartShoot()
    {
        _animation.SwordChargeJerk();
        _jerkCharging = StartCoroutine(JerkCharging());
    }

    private IEnumerator JerkCharging()
    {
        _jerkDistance = 0;

        do
        {
            _jerkDistance += _distanceOneTick;
            _jerkDirection.FillDirection(_jerkDistance / _edit.jerkMaxDistance);
            yield return _chargTick;

        } while (_jerkDistance <= _edit.jerkMaxDistance);

    }

    public override void StopShoot()
    {
        if (_jerkCharging != null)
        {
            StopCoroutine(_jerkCharging);
        }
        
        if (_jerkDistance > _edit.jerkMinDistance)
        {
            StartJerk();
        }
        else
        {
            StopJerk();
        }
        _animation.Jerk();
    }

    private void StartJerk()
    {
        _jerkDirection.FillDirection(0);
        ChangeLayer(_playerColliders, _layerJerkValue);
        _jerkStartPos = _torso.position;
        _jerkCurrentDirection = _torso.forward * _edit.jerkSpeed;
        _isJerk = true;

        int damage = (int)((float)_edit.jerkMaxDamage - _edit.jerkMinDamage * _jerkDistance / _edit.jerkMaxDistance)+_edit.jerkMinDamage; 
        Ray ray = new Ray(_torso.position, _jerkCurrentDirection);
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(ray, 1, _jerkDistance);
        foreach (RaycastHit hit in hits)
        {
            if(hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.Impact(damage);
                if(hit.transform.TryGetComponent<BulletReaction>(out BulletReaction reaction))
                {
                    reaction.Reaction(BulletType.PlayerBullet, hit.point);
                }
            }
        }
        StartCoroutine(StopJerkToTime());
    }

    private IEnumerator StopJerkToTime()
    {
        yield return new WaitForSeconds(0.2f);
        StopJerk();
    }

    private void FixedUpdate()
    {
        if(_isJerk == true)
        {
            if (Vector3.Distance(_torso.position,_jerkStartPos) < _jerkDistance)
            {
                _playerRB.AddForce(_jerkCurrentDirection, ForceMode.Force);
            }
            else
            {
                StopJerk();
            }
        }   
    }

    private void StopJerk()
    {
        _jerkDirection.FillDirection(0);
        _jerkDistance = 0;
        _isJerk = false;
        _playerColliders[0].gameObject.layer = _layerDefaultValue;
        _playerColliders[1].gameObject.layer = _layerJerkValue;
    }

    public override void FastAttak()
    {
        StartCoroutine(CircleAttack());
    }

    private IEnumerator CircleAttack()
    {
        _swordCollisionHandler.OnDamage(true, _edit.circleAttackDamage);
        _animation.SwordCircleAttack();
        _playerColliders[0].gameObject.layer = _layerJerkValue;
        _playerColliders[1].gameObject.layer = _layerDefaultValue;

        yield return new WaitForSeconds(0.5f);

        _swordCollisionHandler.OnDamage(false, 0);
        _playerColliders[0].gameObject.layer = _layerDefaultValue;
        _playerColliders[1].gameObject.layer = _layerJerkValue;
    }

    private void ChangeLayer(Collider[] colliders, int layer)
    {
        foreach (Collider collider in colliders)
        {
            collider.gameObject.layer = layer;
        }
    }
}
