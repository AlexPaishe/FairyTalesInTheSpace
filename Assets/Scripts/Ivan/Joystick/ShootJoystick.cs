using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootJoystick : Joystick
{
    [SerializeField] float _timeLimitQuikTap;
    [SerializeField] private WeaponLoader _weaponLoader;
    [SerializeField] private Events _events;
     
    public bool IsStartedAction {get; private set;}

    bool _isFastAttak = false;
    private bool _isPressed = false;
    private float _timeTap = 0;

    protected override void Start()
    {
        base.Start();
        _events.OnJerkEvent += EndFastAttak;
    }

    private void Update()
    {
        if (_isPressed == true)
        {
            _timeTap += Time.deltaTime;

            if(_timeTap >= _timeLimitQuikTap)
            {
                if(IsStartedAction == false)
                {
                    _weaponLoader.CurrentWeapon.StartShoot();
                    IsStartedAction = true;
                }
            }
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _isPressed = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        if(IsStartedAction == false && _isFastAttak == false)
        {
            _weaponLoader.CurrentWeapon.FastAttak();
            _isFastAttak = true;
        }
        else
        {
            _weaponLoader.CurrentWeapon.StopShoot();
        }

        IsStartedAction = false;
        _timeTap = 0;
        _isPressed = false;
    }

    private void EndFastAttak(bool isEnd)
    {
        if(isEnd == false)
        {
            _isFastAttak = false;
        }
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= EndFastAttak;
    }
}
