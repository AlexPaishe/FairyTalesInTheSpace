using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;

    public KeyDoorType KeyType => _keyType;

    private KeyStorage _keyStorage;

    private KeySound _keySound;

    private void Start()
    {
        _keyStorage = FindObjectOfType<KeyStorage>();
        _keySound = FindObjectOfType<KeySound>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            _keyStorage.AddKey(_keyType);
            _keySound.SoundKey();
            Destroy(gameObject);
        }
    }
}


