using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    [SerializeField] PlayerParts _playerParts;
    [SerializeField] Events _events;

    public Weapon CurrentWeapon { get; private set; }

    private void Awake()
    {
        CurrentWeapon = LoadWeapon();
        CurrentWeapon.Construct(_events, _playerParts);
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
}
