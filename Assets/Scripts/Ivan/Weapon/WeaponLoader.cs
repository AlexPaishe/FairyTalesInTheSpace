using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
    [SerializeField] Transform _rightHand;

    public Weapon CurrentWeapon { get; private set; }

    private void Awake()
    {
        CurrentWeapon = LoadWeapon();
    }

    private Weapon LoadWeapon()
    {
        if (PlayerPrefs.HasKey(GlobalSystemVar.currentWeaponSave) == false)
        {
            PlayerPrefs.SetString(GlobalSystemVar.currentWeaponSave, GlobalSystemVar.sword);
        }

        string path = GlobalSystemVar.weaponPrefsabPath + PlayerPrefs.GetString(GlobalSystemVar.currentWeaponSave);

        GameObject weaponGO = Instantiate(Resources.Load(path, typeof(GameObject)),_rightHand) as GameObject;

        return weaponGO.GetComponent<Weapon>();
    }
}
