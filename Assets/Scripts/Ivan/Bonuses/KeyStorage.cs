using System.Collections.Generic;
using UnityEngine;

public class KeyStorage : MonoBehaviour
{
    [SerializeField] GameObject[] _keysImage;

    private List<KeyDoorType> _keys;

    private void Awake()
    {
        _keys = new List<KeyDoorType>();
    }

    public void AddKey(KeyDoorType key)
    {
        _keys.Add(key);

        AddImageKey(key);
    }

    public void RemoveKey(KeyDoorType key)
    {
        if (_keys.Contains(key))
        {
            _keys.Remove(key);
        }
        // Удалить из панели
    }

    private void AddImageKey(KeyDoorType colour)
    {
        switch (colour)
        {
            case KeyDoorType.Red:
                _keysImage[0].SetActive(true);
                return;
            case KeyDoorType.Blue:
                _keysImage[1].SetActive(true);
                return;
            case KeyDoorType.Green:
                _keysImage[2].SetActive(true);
                return;
            case KeyDoorType.Yellow:
                _keysImage[3].SetActive(true);
                return;
                default:
                return;
        }
    }
}
