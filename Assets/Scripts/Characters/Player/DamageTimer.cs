using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class DamageTimer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private PlayerHealth _player;

    void Awake()
    {
        _player = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        StartCoroutine(DamagePerSecond());
    }

    private IEnumerator DamagePerSecond()
    {
        while (true)
        {
            _player.TakeDamage(1);
            yield return new WaitForSeconds(_delay);
        }
    }
}
