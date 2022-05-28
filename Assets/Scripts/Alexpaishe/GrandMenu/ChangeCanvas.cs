using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject[] _canvas;
    private int _nowCanvas = 0;
    private int _newWeaponInfo = 0;
    private int _newLevelMap = 0;

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
        CanvasChange(0);
    }

    /// <summary>
    /// ����������� � ��������� ����� ������
    /// </summary>
    public void SaveWeaponInfoLoad()
    {
        CanvasChange(1);
    }

    /// <summary>
    /// ���������� ���������� ������ ������
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveWeaponInfo(int newCanvas)
    {
        _newWeaponInfo = newCanvas;
    }

    /// <summary>
    /// ���������� ���������� ���� ������ ������
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveLevelMap(int newCanvas)
    {
        _newLevelMap = newCanvas;
    }

    /// <summary>
    /// ���������� �������� ������ ���� ������ ������
    /// </summary>
    public void SaveLevelMapLoad()
    {
        CanvasChange(2);
    }

    /// <summary>
    /// ���������� ��������� ������ ������
    /// </summary>
    /// <param name="var"></param>
    private void CanvasChange(int var)
    {
        int newCanvas = 0;
        switch(var)
        {
            case 0: newCanvas = _nowCanvas; break;
            case 1: newCanvas = _newWeaponInfo; break;
            case 2: newCanvas = _newLevelMap; break;
        }

        NewCanvas(newCanvas);
    }

    public void Lose()
    {
        _canvas[12].SetActive(false);
    }

    private void OnEnable()
    {
        NewCanvas(0);
    }
}
