using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    private void Start()
    {
        transform.position = _target.position + _offset;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _speed);
    }
}
