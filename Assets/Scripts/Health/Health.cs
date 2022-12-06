using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float _initialHealth = 10f;
    [SerializeField]
    private float _maxHealth = 10f;

    
    [Header("Shield")]
    [SerializeField]
    private float _initialShield = 5f;
    [SerializeField]
    private float _maxShield = 5f;

    [Header("Settings")]
    [SerializeField]
    private bool _destroyObject = false;

    [SerializeField]
    private Character _character;
    [SerializeField]
    private Collider2D _collider2d;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private CharController _characterController;

    public float CurrentHealth { get; set; }
    public float CurrentShield { get; set; }

    private bool _shieldBroken = false;

    private void Awake()
    {
        _character = GetComponent<Character>();
        _collider2d = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _characterController = GetComponent<CharController>();

        CurrentHealth = _initialHealth;
        CurrentShield = _initialShield;
        _shieldBroken = false;

        UIManager.Instance.UpdateHealth(CurrentHealth, _maxHealth);
        UIManager.Instance.UpdateShield(CurrentShield, _maxShield);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {

        if(!_shieldBroken)
        {
            CurrentShield -= damage;
            if(CurrentShield <=0)
            {
                _shieldBroken = true;
            }
        }
        else
        {
            CurrentHealth -= damage;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
        UIManager.Instance.UpdateHealth(CurrentHealth, _maxHealth);
        UIManager.Instance.UpdateShield(CurrentShield, _maxShield);
    }

    private void Die()
    {
        if(_character != null)
        {
            _collider2d.enabled = false;
            _spriteRenderer.enabled = false;
            _character.enabled = false;
            _characterController.enabled = false;
        }

        if(_destroyObject)
        {
            DesroyObj();
        }
    }

    public void Revive()
    {
        if (_character != null)
        {
            _collider2d.enabled = true;
            _spriteRenderer.enabled = true;
            _character.enabled = true;
            _characterController.enabled = true;
            CurrentHealth = _initialHealth;
            CurrentShield = _initialShield;
            _shieldBroken = false;
            UIManager.Instance.UpdateHealth(CurrentHealth, _maxHealth);
            UIManager.Instance.UpdateShield(CurrentShield, _maxShield);
        }

        gameObject.SetActive(true);
    }

    private void DesroyObj()
    {
        gameObject.SetActive(false);
    }
}
