using System;
using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
    [SerializeField] private int _health;
    [SerializeField] private HPBar _hPBar;
    [SerializeField] private Events _events;
    
    private int _maxHealth;
    private bool _isInvulnerability;

    private void Awake()
    {
        _events.OnJerkEvent += OnInvulnerability;
        _maxHealth = _health;
    }

    public void Impact(int damage)
    {
        if (_isInvulnerability == false)
        {
            if (damage < _health)
            {
                TakeDamage(damage);
                //анимаци€
            }
            else
            {
                Dead();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= _health)
        {
            _health -= damage;
        }
        if(_health > _maxHealth)                  // ”словие сработает, если при получении бонуса времени HP стало больше максимального
        {
            _health = _maxHealth;
        }

        _hPBar.UpdateHPBar((float)_health/_maxHealth);
    }

    public void OnInvulnerability(bool value )
    {
        _isInvulnerability = value;
    }
    
    private void Dead()
    {
        //јнимаци€
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= OnInvulnerability;
    }
}
