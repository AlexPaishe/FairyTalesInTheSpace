using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    [SerializeField] int _addedLiveTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Player>(out Player playerHealth))
        {
            playerHealth.Impact(-_addedLiveTime);
            Destroy(gameObject);
        }
    }
}
