using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            Open();
        }
    }

    private void Open()
    {
        _animator.Play("Open");
    }
}
