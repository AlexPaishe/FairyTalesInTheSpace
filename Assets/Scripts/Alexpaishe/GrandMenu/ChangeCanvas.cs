using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject[] _canvas;
    private int _nowCanvas = 0;
    private int _newWeaponInfo = 0;
    private int _newLevelMap = 0;
    private int _yesMenu = 0;

    private void Awake()
    {
        NewCanvas(0);
    }

    /// <summary>
    /// Реализация смены канваса
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
    /// Реализация сохранение последнего канваса
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveMenu(int newCanvas)
    {
        _nowCanvas = newCanvas;
    }

    /// <summary>
    /// Реализация возврата на последний канвас
    /// </summary>
    public void SaveMenuLoad()
    {
        CanvasChange(0);
    }

    /// <summary>
    /// Возвращение в последний выбор оружия
    /// </summary>
    public void SaveWeaponInfoLoad()
    {
        CanvasChange(1);
    }

    /// <summary>
    /// Сохранение последнего выбора оружия
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveWeaponInfo(int newCanvas)
    {
        _newWeaponInfo = newCanvas;
    }

    /// <summary>
    /// Сохранение последнего меню выбора оружия
    /// </summary>
    /// <param name="newCanvas"></param>
    public void SaveLevelMap(int newCanvas)
    {
        _newLevelMap = newCanvas;
    }

    /// <summary>
    /// Реализация Загрузки связки меню выбора уровня
    /// </summary>
    public void SaveLevelMapLoad()
    {
        CanvasChange(2);
    }

    /// <summary>
    /// Реализация отдельных канвас систем
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
            case 3: newCanvas = _yesMenu; break;
        }

        NewCanvas(newCanvas);
    }

    public void Lose()
    {
        _canvas[12].SetActive(false);
    }

    public void YesLoad()
    {
        CanvasChange(3);
        Time.timeScale = 1;
        Base.Death = true;
    }

    public void SaveYesLoad(int newcanvas)
    {
        _yesMenu = newcanvas;
    }

    private void OnEnable()
    {
        NewCanvas(0);
    }
}
