using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(FillingReadiAttak))]
public class ShootJoystick : Joystick
{
    [SerializeField] private float _shootDelay;
    [SerializeField] private WeaponLoader _weaponLoader;

    public bool IsRetention {get; private set;}

    private FillingReadiAttak _fillingReady;
    private bool _longAttakAllowed = true;
    private bool _isSelected = false;
    private float _timer = 0;

    protected override void Start()
    {
        base.Start();
        _fillingReady = GetComponent<FillingReadiAttak>();
    }

    private void Update()
    {
        if(_isSelected == true)
        {
            _timer += Time.deltaTime;

            if(_timer > _shootDelay)
            {
                if (_longAttakAllowed == true)
                {
                    _weaponLoader.CurrentWeapon.StartShoot();
                    IsRetention = true;
                    _longAttakAllowed = false;
                }
            }
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _isSelected = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        if(IsRetention == true)
        {
            _weaponLoader.CurrentWeapon.StopShoot();
            IsRetention = false;
        }
        else
        {
            if (_fillingReady.IsReady == true)
            {
                _weaponLoader.CurrentWeapon.FastAttak();
                _fillingReady.StartReadiness();
            }
        }

        _isSelected = false;
        _longAttakAllowed = true;
        _timer = 0;
    }
}
