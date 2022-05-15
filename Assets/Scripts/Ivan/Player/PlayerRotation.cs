using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private ShootJoystick _shootJoystick;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction;

        if ((_shootJoystick.Horizontal!= 0 || _shootJoystick.Vertical != 0) && _shootJoystick.IsRetention == true)
        {
            direction = new Vector3(_shootJoystick.Horizontal, 0, _shootJoystick.Vertical);
        }
        else if (_moveJoystick.Horizontal != 0 || _moveJoystick.Vertical != 0)
        {
            direction = new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical);
        }
        else
        {
            direction = transform.forward;
        }

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
