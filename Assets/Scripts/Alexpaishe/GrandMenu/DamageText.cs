using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    [SerializeField] private Animator _anima;
    
    public void DamageAnima(int damage)
    {
        if(damage > 0)
        {
            _anima.SetTrigger("Damage");
        }
        else
        {
            _anima.SetTrigger("Health");
        }
    }
}
