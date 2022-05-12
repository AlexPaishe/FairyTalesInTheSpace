using System.Collections.Generic;
using UnityEngine;

public class KeyStorage : MonoBehaviour
{
    [SerializeField] GameObject[] _keyPrefabs;

    public List<GameObject> Keys { get; private set; }

    private void Awake()
    {
        Keys = new List<GameObject>();
    }

    public void AddKey(KeyDoorType keyType)
    {
        Keys.Add(Instantiate(_keyPrefabs[IndexPrefab(keyType)],transform));
    }

    public void RemoveKey(KeyDoorType keyType)
    {
        foreach (GameObject key in Keys)
        {
            if(key.TryGetComponent<KeyImage>(out KeyImage keyImage))
            {
                if (keyImage.KeyType == keyType)
                {
                    Keys.Remove(key);
                    Destroy(key);
                    return;
                }
            }
        }
    }

    public bool IsContainsKey(KeyDoorType keyType)
    {
        bool result = false;

        foreach (GameObject key in Keys)
        {
            if (key.TryGetComponent<KeyImage>(out KeyImage keyImage))
            {
                if (keyImage.KeyType == keyType)
                {
                    result = true;
                }
            }
        }

        return result;
    }

    private int IndexPrefab(KeyDoorType keyType)
    {
        switch (keyType)
        {
            case KeyDoorType.Red:
                return 0;
            case KeyDoorType.Blue:
                return 1;
            case KeyDoorType.Green:
                return 2;
            case KeyDoorType.Yellow:
                return 3;
                default:
                return 0;
        }
    }
}
