using UnityEngine;

public class KeyImage : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;

    public KeyDoorType KeyType => _keyType;
}
