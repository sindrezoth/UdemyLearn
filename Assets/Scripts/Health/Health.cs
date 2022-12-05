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

    [Header("Settings")]
    [SerializeField]
    private bool _destroyObject = false;

    [SerializeField]
    private Character _character;
    [SerializeField]
    private Collider2D _collider2d;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    public float CurrentHealth { get; set; }

    private void Awake()
    {
        _character = GetComponent<Character>();
        _collider2d = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        CurrentHealth = _initialHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            TakeDamage(1);
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Revive();
        }
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
            return;
        }
    }

    private void Die()
    {
        if(_character != null)
        {
            _collider2d.enabled = false;
            _spriteRenderer.enabled = false;

        }

        if(_destroyObject)
        {
            DesroyObj();
        }
    }

    private void Revive()
    {
        if (_character != null)
        {
            _collider2d.enabled = true;
            _spriteRenderer.enabled = true;
            CurrentHealth = _initialHealth;
        }

        gameObject.SetActive(true);
    }

    private void DesroyObj()
    {
        gameObject.SetActive(false);
    }
}
