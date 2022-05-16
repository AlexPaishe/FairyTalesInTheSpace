using System;
using UnityEngine;

public class Player : MonoBehaviour, IHaveHealth
{
    [SerializeField] private Events _events;
    [SerializeField] private DamageTimer _damageTimer;
    [SerializeField] private int _health;

    public int Health => _health;

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
                //��������
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
        if (_health > _maxHealth)                  // ������� ���������, ���� ��� ��������� ������ ������� HP ����� ������ �������������
        {
            _health = _maxHealth;
        }
        _damageTimer.UpdateDisplay();
    }

    public void OnInvulnerability(bool value)
    {
        _isInvulnerability = value;
    }

    private void Dead()
    {
        //��������
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= OnInvulnerability;
    }
}
