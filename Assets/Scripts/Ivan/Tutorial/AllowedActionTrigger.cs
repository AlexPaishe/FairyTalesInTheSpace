using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowedActionTrigger : MonoBehaviour
{
    [SerializeField] Transform _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            if(_door.TryGetComponent<IDoorFromTutor>(out IDoorFromTutor doorFromTutor))
            {
                doorFromTutor.OpeningAllowed = true;
            }
            else
            {
                Debug.Log( $"������������ ��������� {_door} �� ������� {gameObject.name}");
            }
        }
    }
}
