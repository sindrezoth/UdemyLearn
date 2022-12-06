using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharComponents : MonoBehaviour
{
    protected CharController cController;
    protected CharMovement cMovement;
    protected Animator _animator;
    protected Character _character;

    protected float inputHor;
    protected float inputVer;

    protected virtual void Start()
    {
        _character = GetComponent<Character>();
        cController = GetComponent<CharController>();
        cMovement = GetComponent<CharMovement>();
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    protected virtual void HandleAbility()
    {
        InternalInptut();
        HandleInput();
    }

    protected virtual void HandleInput()
    {

    }

    protected virtual void InternalInptut()
    {
        inputHor = Input.GetAxisRaw("Horizontal");
        inputVer = Input.GetAxisRaw("Vertical");
    }


}
