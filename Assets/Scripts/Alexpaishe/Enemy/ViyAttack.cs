using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViyAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
