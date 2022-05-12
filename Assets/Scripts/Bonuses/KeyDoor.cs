using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _key;

    private KeyStorage _keyStorage;

    private void Start()
    {
        _keyStorage = FindObjectOfType<KeyStorage>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<PlayerHealth>())
        {
            _keyStorage.AddKey(_key);
            Destroy(gameObject);
        }
    }
}


