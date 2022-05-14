using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject[] _canvas;
    private int _nowCanvas = 0;
    private int _newWeaponInfo = 0;

    private void Awake()
    {
        NewCanvas(0);
    }

    /// <summary>
    /// ���������� ����� �������
    /// </summary>
    /// <param name="newCanvas"></param>
    public void NewCanvas(int newCanvas)
    {
        for(int i = 0; i < _canvas.Length; i++)
        {
            if(i == newCanvas)
            {
                _canvas[i].SetActive(true);
            }
            else
            {
                _canvas[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// ���������� ���������� ���������� �������
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveMenu(int newCanvas)
    {
        _nowCanvas = newCanvas;
    }

    /// <summary>
    /// ���������� �������� �� ��������� ������
    /// </summary>
    public void SaveMenuLoad()
    {
        for (int i = 0; i < _canvas.Length; i++)
        {
            if (i == _nowCanvas)
            {
                _canvas[i].SetActive(true);
            }
            else
            {
                _canvas[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// ����������� � ��������� ����� ������
    /// </summary>
    public void SaveWeaponInfoLoad()
    {
        for (int i = 0; i < _canvas.Length; i++)
        {
            if (i == _newWeaponInfo)
            {
                _canvas[i].SetActive(true);
            }
            else
            {
                _canvas[i].SetActive(false);
            }
        }
    }

    /// <summary>
    /// ���������� ���������� ������ ������
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveWeaponInfo(int newCanvas)
    {
        _newWeaponInfo = newCanvas;
    }
}
