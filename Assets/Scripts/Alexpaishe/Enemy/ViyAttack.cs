using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class ViyAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ViyMove _viyMove;
    [SerializeField] private float _timeAttack;
    [SerializeField] private float _angelAttack;
    [SerializeField] private float _distanceAttack;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Light _light;
    [SerializeField] private int _damage;

    private bool _isAttacking;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
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
        Vector3 direction = _player.transform.position + Vector3.up - _shootPoint.position;
        Debug.DrawRay(_shootPoint.position, direction, Color.red);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
        _isAttacking = true;
    }

    public void StopLight()
    {
        _light.spotAngle = 0;
    }

    private IEnumerator Shoot()
    {
        float delay = 0.1f;
        while(delay < 1)
        {
            Color colour = new Color(_light.color.r, _light.color.g + 0.1f, _light.color.b + 0.1f);
            _light.color = colour;

            delay++;
            yield return new WaitForSeconds(delay/4);
        }

        DealDamage();

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

    private void DealDamage()
    {
        if (Vector3.Angle(_shootPoint.forward, _player.transform.position - _shootPoint.position) < _angelAttack / 2)
        {
            Vector3 direction = _player.transform.position + Vector3.up - _shootPoint.position;

            Ray ray = new Ray(_shootPoint.position, direction);

            RaycastHit[] hits = Physics.SphereCastAll(ray, 0.5f, _distanceAttack);

            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.TryGetComponent<Player>(out Player player))
                {
                    player.Impact(_damage);
                    return;
                }
            }
        }
    }
}
