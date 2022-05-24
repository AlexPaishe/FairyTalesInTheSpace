using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffect : MonoBehaviour
{
    [SerializeField] private GameObject _decale;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<BulletReaction>(out BulletReaction bulletReaction))
        {
            if (collision.transform.TryGetComponent<Electric>(out Electric electric))
            {
                electric.ElectricEffect = 1;
            }
            else
            {
                Vector3 pos = collision.contacts[0].point;
                pos.y -= 0.4f;
                Instantiate(_decale, pos, Quaternion.identity);
            }
        }
    }
}
