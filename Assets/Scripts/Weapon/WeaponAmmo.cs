using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    private Weapon _weapon;

    private void Start()
    {
        _weapon = GetComponent<Weapon>();
        RefillAmmo();
    }

    public void ConsumeAmmo()
    {
        if(_weapon.UseMagazine && CanUseWeapon())
        {
            _weapon.CurrentAmmo -= 1;
        }
    }

    public bool CanUseWeapon()
    {
        if(_weapon.CurrentAmmo > 0)
        {
            return true;
        }

        return false;
    }

    public void RefillAmmo()
    {
        if(_weapon.UseMagazine)
        {
            _weapon.CurrentAmmo = _weapon.MagazineSize;
        }

    }
}
