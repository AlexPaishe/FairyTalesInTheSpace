using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Portal _secondPortal;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private MeshRenderer[] _mesh;
    [SerializeField] private float _speed;

    private bool _movementAllowed;
    private Coroutine _delayedMove;
    private float _light = 0.1f;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        _movementAllowed = true;
        for(int i = 0; i < _mesh.Length; i++)
        {
            _mesh[i].material.SetFloat("_StrenghtEmission", _light);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_movementAllowed == true)
        {
            if (other.transform.GetComponent<Player>())
            {
                _delayedMove = StartCoroutine(DelayedMove(other.transform));
                StartCoroutine(PortalLight());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            if(_delayedMove != null)
            {
                StopCoroutine(_delayedMove);
            }
        }
    }

    public void StartCharging()
    {
        _audioSource.clip = _clips[1];
        _audioSource.Play();
        StartCoroutine(Charging());
    }

    private IEnumerator DelayedMove(Transform player)
    {
        yield return new WaitForSeconds(0.5f);
        _audioSource.clip = _clips[0];
        _audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        _secondPortal.StartCharging();
        player.position = _secondPortal.transform.position;

        Vector3 newCamPosition = new Vector3(player.position.x, _camera.transform.position.y, player.position.z);
        _camera.transform.position = newCamPosition;
    }

    private IEnumerator Charging()
    {
        _movementAllowed = false;
        yield return new WaitForSeconds(5);
        _movementAllowed = true;
        _audioSource.clip = _clips[2];
        _audioSource.Play();
        _light = 0.1f;
        for (int j = 0; j < _mesh.Length; j++)
        {
            _mesh[j].material.SetFloat("_StrenghtEmission", _light);
        }
    }

    private IEnumerator PortalLight()
    {
        for(int i = 0; i < 20; i++)
        {
            _light += _speed;
            for (int j = 0; j < _mesh.Length; j++)
            {
                _mesh[j].material.SetFloat("_StrenghtEmission", _light);
            }
            yield return new WaitForSeconds(0.05f);
            if(_light > 3)
            {
                break;
            }
        }

        _light = 0;
        for (int j = 0; j < _mesh.Length; j++)
        {
            _mesh[j].material.SetFloat("_StrenghtEmission", _light);
        }
    }
}
