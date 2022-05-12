using System;
using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
    [SerializeField] private int _health;
    [SerializeField] private HPBar _hPBar;

    private int _maxHealth;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void Impact(int damage)
    {
        if (damage < _health)
        {
            TakeDamage(damage);
            //анимация
        }
        else
        {
            Dead();
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= _health)
        {
            _health -= damage;
        }
        if(_health > _maxHealth)                  // Условие сработает, если при получении бонуса времени HP стало больше максимального
        {
            _health = _maxHealth;
        }

        _hPBar.UpdateHPBar((float)_health/_maxHealth);
    }

    private void Dead()
    {
        
    }
}
