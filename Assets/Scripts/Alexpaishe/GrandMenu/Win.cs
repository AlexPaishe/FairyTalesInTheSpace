using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private ChangeCanvas _changeCanvas;
    [SerializeField] private Rang _rang;
    private Player _player;
    private float _enemyLenght;
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
                _changeCanvas.NewCanvas(11);
                _rang.Timer = _player.Health;
                Time.timeScale = 0;
            }
        }
    }

    private void Awake()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        EnemyLenght = enemies.Length;
        _player = FindObjectOfType<Player>();
    }
}
