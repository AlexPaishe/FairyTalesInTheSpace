using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;
    private bool _isOpen;

    public void Open()
    {
        if(_isOpen == false)
        {
            _sound.Play();
            _isOpen = true;
        }
    }
}
