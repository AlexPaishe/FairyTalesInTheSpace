using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private KeyDoorType _keyType;
    [SerializeField] private Renderer _mesh;
    [SerializeField] private Texture[] _texture;
    [SerializeField] private float[] _intensity;

    public KeyDoorType KeyType => _keyType;

    private KeyStorage _keyStorage;

    private void Start()
    {
        _keyStorage = FindObjectOfType<KeyStorage>();
        KeyTypeTexture();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            _keyStorage.AddKey(_keyType);
            Destroy(gameObject);
        }
    }

    private void KeyTypeTexture()
    {
        Color col = Color.white;
        int key = 0;
        switch (_keyType)
        {
            case KeyDoorType.Red: key = 0; col = Color.red; break;
            case KeyDoorType.Blue: key = 1; col = Color.blue;  break;
            case KeyDoorType.Yellow: key = 2; col = Color.yellow; break;
        }

        _mesh.material.mainTexture = _texture[key];
        _mesh.material.SetColor("_EmissionColor", col * Mathf.Pow(2, _intensity[key]));
    }
}


