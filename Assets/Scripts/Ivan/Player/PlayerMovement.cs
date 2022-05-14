using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private MoveJoystick _moveJoystick;
    [SerializeField] private Events _events;

    private Rigidbody _rigidbody;
    private bool _moveAllowed = true;

    private void Start()
    {
        _events.OnJerkEvent += SetPermissionStatus;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_moveJoystick != null && _moveAllowed == true)
        {
            _rigidbody.velocity = new Vector3(_moveJoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _moveJoystick.Vertical * _moveSpeed);
        }
    }

    public void SetPermissionStatus(bool isJerk)
    {
        _moveAllowed = !isJerk;
    }

    private void OnDisable()
    {
        _events.OnJerkEvent -= SetPermissionStatus;
    }
}
