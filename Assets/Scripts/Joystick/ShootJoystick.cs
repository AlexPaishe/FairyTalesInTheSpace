using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootJoystick : Joystick
{
    [SerializeField] private WeaponChange _weaponChange;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _weaponChange.CurretWeapon.StartShoot();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _weaponChange.CurretWeapon.StopShoot();
    }
}
