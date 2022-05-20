using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private Events _events;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private Rigidbody _rigidbody;
    private bool _moveAllowed = true;
    private bool _isRun;

    private void Start()
    {
        _events.OnJerkEvent += SetPermissionStatus;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();

        float moveAmount = Mathf.Clamp01(
            Mathf.Abs(_moveJoystick.Horizontal)
            + Mathf.Abs(_moveJoystick.Vertical)
            );

        _playerAnimation.SetMoveSpeed(moveAmount);
        //_animator.SetFloat("vertical", moveAmount, 0.15f, Time.deltaTime);
    }

    public void SetPermissionStatus(bool isJerk)
    {
        _moveAllowed = !isJerk;
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= SetPermissionStatus;
    }

    private void Movement()
    {
        if (_moveJoystick != null && _moveAllowed == true)
        {
            _rigidbody.velocity = new Vector3(
                _moveJoystick.Horizontal * _moveSpeed,
                _rigidbody.velocity.y,
                _moveJoystick.Vertical * _moveSpeed);
        }
    }
}
