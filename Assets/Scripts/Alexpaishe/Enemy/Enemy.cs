using UnityEngine;

public class Enemy : MonoBehaviour, IHaveHealth
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
            _health -= damage;
            _hPBar.UpdateHPBar((float)_health / _maxHealth);
            //включить анимацию получения урона
        }
        else
        {
            Dead();
        }
    }

    private void Dead()
    {
        //анимация смерти

        Destroy(gameObject);
    }
}
