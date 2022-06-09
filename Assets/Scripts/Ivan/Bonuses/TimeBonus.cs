using UnityEngine;
using UnityEngine.UI;

public class TimeBonus : MonoBehaviour
{
    [SerializeField] private int _addedLiveTime;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Text _text;

    private void Start()
    {
        _text.text = _addedLiveTime.ToString();
    }

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
