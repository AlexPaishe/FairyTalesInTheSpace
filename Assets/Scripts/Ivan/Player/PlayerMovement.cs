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
        _events.OnJerkEvent += BanMovement;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 direction;

        if(_moveJoystick.Direction != Vector2.zero)
        {
            direction = DirectionMoveJoystick();
        }
        else
        {
            direction = DirectionWASD();
        }

        _rigidbody.velocity = direction.normalized * _moveSpeed;

        float moveSpeed = _rigidbody.velocity.normalized.magnitude;
        _playerAnimation.SetMoveSpeed(moveSpeed);
    }

    public void BanMovement(bool isBun)
    {
        _moveAllowed = !isBun;
    }

    public void RestMovement()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= BanMovement;
    }

    private Vector3 DirectionMoveJoystick()
    {
        Vector3 direction;
        if (_moveJoystick != null && _moveAllowed == true)
        {
            direction = new Vector3(
                _moveJoystick.Direction.x,
                _rigidbody.velocity.y,
                _moveJoystick.Direction.y);
        }
        else
        {
            direction = Vector3.zero;
        }
        return direction;
    }

    private Vector3 DirectionWASD()
    {
        return new Vector3(
            Input.GetAxis("Horizontal"),
            _rigidbody.velocity.y,
            Input.GetAxis("Vertical"));
    }
}
