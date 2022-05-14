using System;
using UnityEngine;

public class Events : MonoBehaviour
{
    public event Action<bool> OnJerkEvent;

    public void Jerk(bool isCommited)
    {
        this.OnJerkEvent?.Invoke(isCommited);
    }
}
