using UnityEngine;

public class Enemy : MonoBehaviour, IHaveHealth
{
    [SerializeField] private int _health;
    [SerializeField] private HPBar _hPBar;

    private int _maxHealth;
    private bool _isDead;

    private void Start()
    {
        _maxHealth = _health;
    }

    public void Impact(int damage)
    {
        if (_isDead == false)
        {
            _health -= damage;

            _hPBar.TakeDamage((float)damage/_maxHealth);

            if (_health <= 0)
            {
                Dead();
            }
            else
            {
                //включить анимацию получения урона
            }
        }
    }

    private void Dead()
    {
        //анимация смерти

        _isDead = true;
        Destroy(gameObject);
    }
}
