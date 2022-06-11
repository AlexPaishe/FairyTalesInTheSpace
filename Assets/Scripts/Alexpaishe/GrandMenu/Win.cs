using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private ChangeCanvas _changeCanvas;
    [SerializeField] private Rang _rang;
    [SerializeField] private InfoSearch _search;
    [SerializeField] private Text[] _nameLevelText;
    [SerializeField] private string[] _nameLevel;
    [SerializeField] private GameObject[] _rangInfo;
    private Player _player;
    private MenuSound _sound;
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
                    NewRangeTitle();
                }
            }
        }
    }

    private void Awake()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        EnemyLenght = enemies.Length;
        _player = FindObjectOfType<Player>();
        _sound = FindObjectOfType<MenuSound>();
    }

    public void Lose()
    {
        _lose = true;
    }

    private void NewRangeTitle()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        for(int i = 0; i < _rangInfo.Length;i++)
        {
            if(i == level-1)
            {
                for(int j = 0; j < _nameLevelText.Length;j++)
                {
                    _nameLevelText[j].text = _nameLevel[i];
                }
                _rangInfo[i].SetActive(true);
            }
            else
            {
                _rangInfo[i].SetActive(false);
            }
        }
        _sound.WinAndLose(0);
    }
}
