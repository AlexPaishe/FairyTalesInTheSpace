using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private SwordEdit _edit;

    private PlayerAnimation _animation;
    private Events _events;
    private Rigidbody _playerRB;
    private Transform _legs;
    private Transform _torso;

    private void Start()
    {
        _animation = base.PlayerParts.Father.GetComponent<PlayerAnimation>();
        _events = base.Events;
        _playerRB = base.PlayerParts.Rigidbody;
        _legs = base.PlayerParts.Legs;
        _torso = base.PlayerParts.Torso;

        _animation.WeaponChange(1);
    }

    public override void StartShoot()
    {
        _animation.SwordChargeJerk();
    }

    public override void StopShoot()
    {
        _animation.Jerk();
    }

    public override void FastAttak()
    {
        _animation.SwordCircleAttack();
    }
}
