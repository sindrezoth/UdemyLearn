using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Settings")]
    [SerializeField]
    private Image _healthBar;
    [SerializeField]
    private TextMeshProUGUI _healthBarTMP;
    [SerializeField]
    private Image _shieldBar;
    [SerializeField]
    private TextMeshProUGUI _shieldBarTMP;

    private float _playerCurrentHealth;
    private float _playerMaxHealth;
    private float _playerCurrentShield;
    private float _playerMaxShield;

    private void Update()
    {
        InternalUpdate();
    }

    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        _playerCurrentHealth = currentHealth;
        _playerMaxHealth = maxHealth;
    }

    public void UpdateShield(float currentShield, float maxShield)
    {
        _playerCurrentShield = currentShield;
        _playerMaxShield = maxShield;
    }

    private void InternalUpdate()
    {
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _playerCurrentHealth / _playerMaxHealth, 10f * Time.deltaTime);
        _healthBarTMP.text = _playerCurrentHealth.ToString() + "/" + _playerMaxHealth.ToString();
        _shieldBar.fillAmount = Mathf.Lerp(_shieldBar.fillAmount, _playerCurrentShield / _playerMaxShield, 10f * Time.deltaTime);
        _shieldBarTMP.text = _playerCurrentShield.ToString() + "/" + _playerMaxShield.ToString();
    }
}
