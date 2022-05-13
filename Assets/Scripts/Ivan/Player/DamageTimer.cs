using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class DamageTimer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private Player _player;

    void Awake()
    {
        _player = GetComponent<Player>();
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

    private void OnDisable()
    {
        StopCoroutine(DamagePerSecond());
    }
}
