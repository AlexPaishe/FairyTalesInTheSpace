using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private BlasterEdit _edit;

    public override int Index => 2;

    private PlayerAnimation _animation;
    private Transform _torso;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _torso = base.PlayerParts.Torso;
    }

    public override void StartShoot()
    {
        Debug.Log("Я заряжаю выстрел");
    }

    public override void StopShoot()
    {
        Debug.Log("Я выстрелил");
    }

    public override void FastAttak()
    {
        Debug.Log("Я выстрелил вверх");
    }
}
