using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform _movePosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.TryGetComponent<PlayerParts>(out PlayerParts playerParts))
        {
            playerParts.transform.position = _movePosition.position;
            playerParts.Legs.rotation = _movePosition.rotation;
        }
    }
}
