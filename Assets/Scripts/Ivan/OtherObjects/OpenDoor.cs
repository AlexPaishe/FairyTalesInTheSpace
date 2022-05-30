using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private Animator _animator;
    private bool _isOpen;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_isOpen == false)
        {
            if (other.transform.GetComponent<Player>())
            {
                Open();
            }
        }
    }

    private void Open()
    {
        _animator.Play("Open");
        _source.Play();
        _isOpen = true;
    }
}
