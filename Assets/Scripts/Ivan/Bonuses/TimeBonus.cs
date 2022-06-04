using UnityEngine;

public class TimeBonus : MonoBehaviour
{
    [SerializeField] int _addedLiveTime;
    [SerializeField] AudioSource _audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Player>(out Player playerHealth))
        {
            _audioSource.Play();
            playerHealth.Impact(-_addedLiveTime);
            Destroy(gameObject);
        }
    }
}
