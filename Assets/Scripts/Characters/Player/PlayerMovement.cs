using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private MoveJoystick _moveJoystick;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_moveJoystick != null)
        {
            _rigidbody.velocity = new Vector3(_moveJoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _moveJoystick.Vertical * _moveSpeed);
        }
    }
}
