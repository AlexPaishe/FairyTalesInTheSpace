using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpawnEnemy : MonoBehaviour
{
    [SerializeField] private int _countEnemy;
    [SerializeField] private Events _events;
    [SerializeField] private GameObject[] _hiddenEnemys;
    [SerializeField] private TutorialDisplay _tutorialDisplay;
    [SerializeField] private OpenDoorForTutor _door;
    [SerializeField] private WeaponLoader _weaponLoader;

    private int _secondWeaponStep;
    private string _secondWeaponName;

    private void Start()
    {
        foreach (var item in _hiddenEnemys)
        {
            item.SetActive(false);
        }

        _events.OnEnemyDeadEvent += EnemyDead;

        if (PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave) == GlobalSystemVar.izlar)
        {
            _door.step = 8;
            _secondWeaponStep = 7;
            _secondWeaponName = GlobalSystemVar.sword;
        }
        else
        {
            _door.step = 7;
            _secondWeaponStep = 8;
            _secondWeaponName= GlobalSystemVar.izlar;
        }
    }

    private void EnemyDead()
    {
        _countEnemy--;
        if (_countEnemy <= 0)
        {
            SpawnNewEnemy();
            _events.OnEnemyDeadEvent -= EnemyDead;
        }
    }

    private void SpawnNewEnemy()
    {
        foreach (var item in _hiddenEnemys)
        {
            item.SetActive(true);
        }

        _weaponLoader.ChangeWeapon(_secondWeaponName);

        _tutorialDisplay.OnDisplayToTrigger(_secondWeaponStep);
    }

    private void OnDisable()
    {
        _events.OnEnemyDeadEvent -= EnemyDead;
    }
}
