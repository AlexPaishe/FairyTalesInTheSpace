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

        float moveSpeed = _rigidbody.velocity.normalized.magnitude;
        _playerAnimation.SetMoveSpeed(moveSpeed);
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
            Vector3 direction = new Vector3(
                _moveJoystick.Direction.x,
                _rigidbody.velocity.y,
                _moveJoystick.Direction.y);

            _rigidbody.velocity = direction.normalized * _moveSpeed;
        }
    }
}
