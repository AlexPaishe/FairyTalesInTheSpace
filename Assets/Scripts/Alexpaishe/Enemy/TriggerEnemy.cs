using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<ITriggerMove>(out ITriggerMove trigger))
        {
            trigger.StartMove(transform);
        }
    }
}
