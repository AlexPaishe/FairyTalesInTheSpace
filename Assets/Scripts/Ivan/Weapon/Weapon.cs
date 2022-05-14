using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public virtual float TimeReadyFastAttack { get; private set; }
    public virtual int DamageFastAttack { get; private set; }
    public virtual float ForceFastAttack { get; private set; }

    public virtual void StartShoot()
    {

    }

    public virtual void StopShoot()
    {

    }

    public virtual void FastAttak()
    {

    }
}
