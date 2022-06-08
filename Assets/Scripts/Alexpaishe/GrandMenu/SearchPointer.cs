using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPointer : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private GameObject _searchButton;

    private void Awake()
    {
        Base.SeeEnemy = false;
    }

    public void StartSearch()
    {
        StartCoroutine(Search());
    }

    private IEnumerator Search()
    {
        Base.SeeEnemy = true;
        yield return new WaitForSeconds(_timer);
        _searchButton.SetActive(false);
        Base.SeeEnemy = false;
        yield return new WaitForSeconds(_timer);
        _searchButton.SetActive(true);
    }
}
