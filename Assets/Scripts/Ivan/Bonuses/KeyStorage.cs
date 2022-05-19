using System.Collections.Generic;
using UnityEngine;

public class KeyStorage : MonoBehaviour
{
    [SerializeField] KeyImage[] _keysImage;

    private void Awake()
    {
        HideAllKeys();
    }

    public void AddKey(KeyDoorType keyType)
    {
        foreach (var key in _keysImage)
        {
            if (key.KeyType == keyType)
            {
                key.gameObject.SetActive(true);
            }
        }
    }

    public bool IsContainsKey(KeyDoorType keyType)
    {
        bool result = false;

        foreach (var key in _keysImage)
        {
            if (key.KeyType == keyType && key.gameObject.activeSelf == true)
            {
                result = true;
            }
        }

        return result;
    }

    private void HideAllKeys()
    {
        for (int i = 0; i < _keysImage.Length; i++)
        {
            _keysImage[i].gameObject.SetActive(false);
        }
    }
}
