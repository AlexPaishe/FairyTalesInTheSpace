using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    [SerializeField] private ChangeCanvas _canvas;
    [SerializeField] private CapsuleCollider _col;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PauseMenu _pause;

    public void DeadBegin()
    {
        _canvas.Lose();
        _rb.isKinematic = true;
        _col.enabled = false;
    }

    public void DeadEnd()
    {
        _pause.Lose();
        _canvas.NewCanvas(10);
    }
}
