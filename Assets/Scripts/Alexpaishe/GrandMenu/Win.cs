using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private ChangeCanvas _changeCanvas;
    [SerializeField] private Rang _rang;
    [SerializeField] private InfoSearch _search;
    private Player _player;
    private float _enemyLenght;
    private bool _lose = false;
    public float EnemyLenght
    {
        get
        {
            return _enemyLenght;
        }

        set
        {
            _enemyLenght = value;
            if(_enemyLenght == 0)
            {
                if (_lose == false)
                {
                    _changeCanvas.NewCanvas(11);
                    _rang.Timer = _player.Health;
                    _search.Init();
                }
            }
        }
    }

    private void Awake()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        EnemyLenght = enemies.Length;
        _player = FindObjectOfType<Player>();
    }

    public void Lose()
    {
        _lose = true;
    }
}
