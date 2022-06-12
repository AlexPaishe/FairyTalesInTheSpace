using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPointer : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;
    private Transform _point;
    private Camera _cam;
    private TriggerEnemy _playerT;
    private Transform _player;
    private SearchPointer _search;
    private CanvasGroup _canvas;
    private GameObject _pointArrow;

    void Start()
    {
        _cam = Camera.main;
        _playerT = FindObjectOfType<TriggerEnemy>();
        _player = _playerT.gameObject.transform;
        _search = FindObjectOfType<SearchPointer>();
        GameObject point = Instantiate(_pointer, _search.gameObject.transform);
        _point = point.transform;
        _canvas = point.GetComponent<CanvasGroup>();
        _pointArrow = point;
    }

    void Update()
    {
        if(Base.SeeEnemy == true)
        {
            Vector3 distancePlayerToEnemy = transform.position - _player.position;
            Ray ray = new Ray(_player.position, distancePlayerToEnemy);
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_cam);
            float minDistance = Mathf.Infinity;
            int planeIndex = 0;
            for(int i = 0; i < 4; i++)
            {
                if(planes[i].Raycast(ray, out float distane))
                {
                    if(distane < minDistance)
                    {
                        minDistance = distane;
                        planeIndex = i;
                    }
                }
            }
            if(minDistance > distancePlayerToEnemy.magnitude)
            {
                _canvas.alpha = 0;
            }
            else
            {
                _canvas.alpha = 1;
            }
            minDistance = Mathf.Clamp(minDistance, 0, distancePlayerToEnemy.magnitude);
            Vector3 worldPos = ray.GetPoint(minDistance);
            _point.position = _cam.WorldToScreenPoint(worldPos);
            _point.rotation = GetIconRotation(planeIndex);
        }
        else
        {
            _canvas.alpha = 0;
        }
    }

    private Quaternion GetIconRotation(int planeIndex)
    {
        switch(planeIndex)
        {
            case 0: return Quaternion.Euler(0f, 0f, 90f);
                break;
            case 1: return Quaternion.Euler(0f, 0f, -90f);
                break;
            case 2:return Quaternion.Euler(0f, 0f, 180f);
                break;
            case 3: return Quaternion.Euler(0f, 0f, 0f);
                break;
        }
        return Quaternion.identity;
    }

    public void PointArrow()
    {
        _pointArrow.SetActive(false);
    }
}
