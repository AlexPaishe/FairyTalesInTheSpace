using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;

    public void UpdateHPBar(float healthPercent)
    {
        _healthBarFilling.fillAmount = healthPercent;
    }
}
