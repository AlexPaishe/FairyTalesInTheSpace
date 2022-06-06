using System;
using UnityEngine;

public class Events : MonoBehaviour
{
    public event Action<bool> OnJerkEvent;
    public event Action OnEnemyDeadEvent;

    public void Jerk(bool isCommited)
    {
        this.OnJerkEvent?.Invoke(isCommited);
    }

    public void EnemyDead()
    {
        this.OnEnemyDeadEvent?.Invoke();
    }
}
