using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;

    private int _indexCurrentWeapon = 0;

    public Weapon CurretWeapon => _weapons[_indexCurrentWeapon];

    public void ChangeWeapon()
    {
        _weapons[_indexCurrentWeapon].gameObject.SetActive(false);

        int weaponCount = _weapons.Length;

        if(_indexCurrentWeapon != weaponCount-1)
        {
            _indexCurrentWeapon++;
        }
        else
        {
            _indexCurrentWeapon = 0;
        }

        _weapons[_indexCurrentWeapon].gameObject.SetActive(true);
    }
}
