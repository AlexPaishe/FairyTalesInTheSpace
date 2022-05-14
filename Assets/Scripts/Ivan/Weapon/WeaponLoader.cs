using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    [SerializeField] Transform _rightHandPoint;

    public Weapon CurrentWeapon { get; private set; }

    private void Awake()
    {
        CurrentWeapon = LoadWeapon();
    }

    private Weapon LoadWeapon()
    {
        if (PlayerPrefs.HasKey(GlobalSystemVar.currentWeaponSave) == false)
        {
            PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.izlar);
        }

        string path = GlobalSystemVar.weaponPrefsabPath + PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);

        GameObject weaponGO = Instantiate(Resources.Load(path, typeof(GameObject)),_rightHandPoint) as GameObject;

        return weaponGO.GetComponent<Weapon>();
    }
}
