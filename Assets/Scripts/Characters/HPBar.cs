using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void TakeDamage(float damagePercent)
    {
        _healthBarFilling.fillAmount -= damagePercent;
    }

    private void LateUpdate()
    {
        transform.LookAt(new Vector3(transform.position.x, _camera.transform.position.y, _camera.transform.position.z));
        transform.Rotate(0, 180, 0);
    }
}
