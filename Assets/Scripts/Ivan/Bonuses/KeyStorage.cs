using System.Collections.Generic;
using UnityEngine;

public class KeyStorage : MonoBehaviour
{
    [SerializeField] KeyImage[] _keysImage;
    [SerializeField] private Sound _sound;

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
                _sound.SoundPlay(0);
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
