using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private float _shotCD = 0.5f;

    [Header("Weapon")]
    [SerializeField]
    private bool _useMagazine = true;
    [SerializeField]
    private float _magazineSize = 30;
    [SerializeField]
    private bool _autoReload = true;

    public Character _weaponOwner { get; private set; }

    public float CurrentAmmo { get; set; }
    public bool UseMagazine => _useMagazine;
    public float MagazineSize => _magazineSize;

    private WeaponAmmo _weaponAmmo;

    private bool _canShoot;
    private float _nextShootTime;

    private void Update()
    {
        WeaponCanShot();
    }

    private void Awake()
    {
        _weaponAmmo = GetComponent<WeaponAmmo>();
        CurrentAmmo = _magazineSize;
    }

    public void TriggerShot()
    {
        StartShooting();
    }

    public void SetOwner(Character owner)
    {
        _weaponOwner = owner;
    }

    public void Reload()
    {
        if(_weaponAmmo != null)
        {
            if(_useMagazine)
            {
                _weaponAmmo.RefillAmmo();
            }
        }
        
    }   
    
    private void StartShooting()
    {
        if (_useMagazine)
        {
            if (_weaponAmmo != null)
            {
                if (_weaponAmmo.CanUseWeapon())
                {
                    RequestShot();
                }
                else
                {
                    if (_autoReload)
                    {
                        Reload();
                    }
                }
            }
        }
        else
        {
            RequestShot();
        }
    }

    private void RequestShot()
    {
        if(!_canShoot)
        {
            return;
        }

        Debug.Log("Shot");
        _weaponAmmo.ConsumeAmmo();
        _nextShootTime = Time.fixedTime + _shotCD;
        _canShoot = false;
    }

    private void WeaponCanShot()
    {
        if (Time.fixedTime > _nextShootTime)
        {
            _canShoot = true;
        }
    }
}
