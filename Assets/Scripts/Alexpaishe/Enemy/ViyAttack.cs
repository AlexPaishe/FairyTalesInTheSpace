using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViyAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ViyMove _viyMove;
    [SerializeField] private float _timeAttack;
    [SerializeField] private float _angelAttack;
    [SerializeField] private float _distanceAttack;
    [SerializeField] private Player _player;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Light _light;

    private bool _isAttacking;
    private Ray _rayAttack;

    private void Start()
    {
    }

    private void Update()
    {
        if (_isAttacking == true)
        {
            float counter = 0;

            if(counter < _timeAttack)
            {
                if (_light.spotAngle < _angelAttack)
                {
                    _light.spotAngle += Time.deltaTime / _timeAttack * _angelAttack;
                }

                counter+= Time.deltaTime;
            }
        }
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _isAttacking = true;
    }

    private IEnumerator Shoot()
    {
        float delay = 0.1f;
        while(delay < 1)
        {
            Color colour = new Color(_light.color.r, _light.color.g + 0.1f, _light.color.b + 0.1f);
            _light.color = colour;

            delay++;
            yield return new WaitForSeconds(delay);
        }
        _rayAttack = new Ray(_shootPoint.position, _shootPoint.forward * _distanceAttack);

        _viyMove.IsAttack = false;
        _isAttacking = false;

        Color color = new Color(_light.color.r, 0, 0);
        _light.color = color;

        _light.spotAngle = 0;
    }

    public void EndAttack()
    {
        StartCoroutine(Shoot());
    }
}
