using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWeapon : CharComponents
{
    [Header("Weapon settings")]
    [SerializeField]
    private Weapon _weaponToUse;
    [SerializeField]
    private Transform _weaponHolderPosition;

    private Weapon _currentWeapon;

    private void Start()
    {
        base.Start();
        Equip(_weaponToUse, _weaponHolderPosition);
    }

    protected override void HandleAbility()
    {
        if(Input.GetMouseButton(0))
        {
            Shot();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }    

    private void Shot()
    {
        if(_currentWeapon ==null)
        {
            return;
        }

        _currentWeapon.TriggerShot();
    }

    private void Reload()
    {
        if (_currentWeapon == null)
        {
            return;
        }

        _currentWeapon.Reload();
    }

    private void Equip(Weapon weapon, Transform holderPosition)
    {
        _currentWeapon = Instantiate(weapon, holderPosition.position, holderPosition.rotation, _weaponHolderPosition);
        _currentWeapon.SetOwner(_character);
    }
}
