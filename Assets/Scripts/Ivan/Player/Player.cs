using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
    [SerializeField] private Events _events;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private DamageTimer _damageTimer;
    [SerializeField] private int _health;
    [SerializeField] private PlayerParts _playerParts;
    [SerializeField] private Material _kosMat;
    [SerializeField] private DamageText _damageText;

    public int Health => _health;

    private int _maxHealth;
    private bool _isInvulnerability;

    private void Awake()
    {
        _events.OnJerkEvent += OnInvulnerability;
        _maxHealth = _health;
        _kosMat.SetFloat("_EmissionStrenght", 30);
        _kosMat.SetFloat("_Electric", 0);
    }

    public void Impact(int damage)
    {
        if (_isInvulnerability == false)
        {
            _damageText.DamageAnima(damage);
            StartCoroutine(Damage());
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
    }

    public void TakeDamage(int damage)
    {
        if (damage <= _health)
        {
            _health -= damage;
        }
        if (_health > _maxHealth)                  // Условие сработает, если при получении бонуса времени HP стало больше максимального
        {
            _health = _maxHealth;
        }
        if(_health > 0)
        {
            _kosMat.SetFloat("_EmissionStrenght", 30);
        }
        else
        {
            _kosMat.SetFloat("_EmissionStrenght", 0);
        }
        _damageTimer.UpdateDisplay();
    }

    public void OnInvulnerability(bool value)
    {
        _isInvulnerability = value;
    }

    private void Dead()
    {
        _animation.Dead();
    }

    public void TestDead()   //Метод для тестовой кнопки
    {
        _playerParts.Torso.rotation = _playerParts.Legs.rotation;
        _animation.Dead();
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= OnInvulnerability;
    }

    private IEnumerator Damage()
    {
        _kosMat.SetFloat("_Electric", 1);
        yield return new WaitForSeconds(0.5f);
        _kosMat.SetFloat("_Electric", 0);
    }
}
