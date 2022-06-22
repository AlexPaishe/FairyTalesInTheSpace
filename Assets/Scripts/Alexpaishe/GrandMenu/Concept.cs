using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Concept : MonoBehaviour
{
    [SerializeField] private Image _concept;
    [SerializeField] private Sprite[] _newConcept;
    [Space]
    [SerializeField] private Text _conceptName;
    [SerializeField] private string[] _conceptText;
    private int _current;
    private int _maxLeight;
    public int Current
    {
        get { return _current; }
        set
        {
            _current = value;
            if(_current < 0)
            {
                _current = _maxLeight - 1;
            }
            else if(_current == _maxLeight)
            {
                _current = 0;
            }
            _concept.sprite = _newConcept[_current];
            _conceptName.text = _conceptText[_current];
        }
    }
    void Start()
    {
        _maxLeight = _newConcept.Length;
    }

    public void LeftConcept()
    {
        Current--;
    }

    public void RightConcent()
    {
        Current++;
    }
}
