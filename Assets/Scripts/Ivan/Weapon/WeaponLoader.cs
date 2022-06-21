using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    [SerializeField] private PlayerParts _playerParts;
    [SerializeField] private Events _events;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private bool _isTutorial;

    private PlayerRotation _rotation;

    public Weapon CurrentWeapon { get; private set; }

    private void Awake()
    {
        _rotation = _playerParts.Father.GetComponent<PlayerRotation>();

        if(_isTutorial == false)
        {
            CurrentWeapon = LoadWeapon();
            _playerAnimation.WeaponChange(CurrentWeapon.Index);
            CurrentWeapon.Construct(_events, _playerParts);
        }
        else
        {
            CurrentWeapon = LoadWeapon(GlobalSystemVar.unarmed);
            _playerAnimation.WeaponChange(CurrentWeapon.Index);
            CurrentWeapon.Construct(_events, _playerParts);
        }
    }

    private Weapon LoadWeapon()
    {
        if (PlayerPrefs.HasKey(GlobalSystemVar.currentWeaponSave) == false)
        {
            PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.izlar);
        }

        string path = GlobalSystemVar.weaponPrefsabPath + PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);

        GameObject weaponGO = Instantiate(Resources.Load(path, typeof(GameObject)), _playerParts.RightHandPoint) as GameObject;

        return weaponGO.GetComponent<Weapon>();
    }

    private Weapon LoadWeapon(string weapon)
    {
        string path = GlobalSystemVar.weaponPrefsabPath + weapon;
        GameObject weaponGO = Instantiate(Resources.Load(path, typeof(GameObject)), _playerParts.RightHandPoint) as GameObject;
        return weaponGO.GetComponent<Weapon>();
    }

    public void ChangeWeapon(string weapon)
    {
        CurrentWeapon.StopShoot();
        CurrentWeapon.Delete();
        CurrentWeapon = LoadWeapon(weapon);
        _playerAnimation.WeaponChange(CurrentWeapon.Index);
        CurrentWeapon.Construct(_events, _playerParts);
        _rotation.BlockedRotate = false;
    }
}
