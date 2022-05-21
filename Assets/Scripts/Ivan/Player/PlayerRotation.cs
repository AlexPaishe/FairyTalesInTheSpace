using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private ShootJoystick _shootJoystick;
    [SerializeField] private Transform _playerTorso;
    [SerializeField] private Transform _playerLegs;
 
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_shootJoystick.Horizontal != 0 || _shootJoystick.Vertical != 0)
        {
            Vector3 direction = new Vector3(_shootJoystick.Horizontal, 0, _shootJoystick.Vertical);
            _playerTorso.rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            Vector3 direction = new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical);
            _playerTorso.rotation = _playerLegs.rotation;
        }

        if (_moveJoystick.Horizontal != 0 || _moveJoystick.Vertical != 0)
        {
            Vector3 direction = new Vector3(_moveJoystick.Horizontal, 0, _moveJoystick.Vertical);
            _playerLegs.rotation = Quaternion.LookRotation(direction);
        }
    }
}
