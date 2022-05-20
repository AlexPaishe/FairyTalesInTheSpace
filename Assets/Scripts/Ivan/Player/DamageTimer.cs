using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageTimer : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;
    [SerializeField] private Player _player;
    [SerializeField] private Text _timerText;

    private Coroutine _coroutine;

    private void Start()
    {
        UpdateDisplay();
        _coroutine = StartCoroutine(DamagePerSecond());
    }

    private IEnumerator DamagePerSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            _player.TakeDamage(_damage);
            UpdateDisplay();
        }
    }

    public void UpdateDisplay()
    {
        _timerText.text = _player.Health.ToString();
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }
}
