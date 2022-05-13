using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootJoystick : Joystick
{
    [SerializeField] private WeaponLoader _weaponChange;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _weaponChange.CurrentWeapon.StartShoot();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _weaponChange.CurrentWeapon.StopShoot();
    }
}
