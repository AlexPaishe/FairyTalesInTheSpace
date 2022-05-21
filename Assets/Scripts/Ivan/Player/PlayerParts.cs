using UnityEngine;

public class PlayerParts : MonoBehaviour
{
    [SerializeField] private Transform _father;
    [SerializeField] private Transform _legs;
    [SerializeField] private Transform _torso;
    [SerializeField] private Transform _leftHandPoint;
    [SerializeField] private Transform _rightHandPoint;
    [SerializeField] private Rigidbody _rigidbody;

    public Transform Father => _father;
    public Transform Legs => _legs;
    public Transform Torso => _torso;
    public Transform LeftHandPoint => _leftHandPoint;
    public Transform RightHandPoint => _rightHandPoint;
    public Rigidbody Rigidbody => _rigidbody;
}
