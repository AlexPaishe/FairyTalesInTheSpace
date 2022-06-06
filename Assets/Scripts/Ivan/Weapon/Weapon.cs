using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public virtual float TimeReadyFastAttack { get; private set; }
    public virtual int DamageFastAttack { get; private set; }
    public virtual float ForceFastAttack { get; private set; }
    public virtual Events Events { get; private set; }
    public virtual PlayerParts PlayerParts { get; private set; }

    public virtual void Construct(Events events, PlayerParts playerParts)
    {
        this.Events = events;
        this.PlayerParts = playerParts;
    }

    public virtual void StartShoot()
    {

    }

    public virtual void StopShoot()
    {

    }

    public virtual void FastAttak()
    {

    }

    public virtual void Delete()
    {
        Destroy(this.gameObject);
    }
}
