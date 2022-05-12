using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessage : MonoBehaviour
{
    [SerializeField] private Text _text;
    
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void DisplayMessage(string text)
    {
        _text.text = text;
        _animator.SetTrigger("SendMessage");
    }
}
