using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : CharComponents
{
    [SerializeField]
    private float _walkSpeed = 8f;

    private readonly int _moveParameter = Animator.StringToHash("Moving");
    
    public float MoveSpeed { get; set; }

    protected override void Start()
    {
        base.Start();
        MoveSpeed = _walkSpeed;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimation();
    }

    private void MoveCharacter()
    {
        Vector2 movement = new Vector2(inputHor, inputVer);
        Vector2 movementNormalized = movement.normalized;
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        cController.SetMovement(movementSpeed);
    }

    private void UpdateAnimation()
    {
        if(cController.CurrentMovement.normalized.magnitude > 0.1)
        {
            _animator.SetBool(_moveParameter, true);
        }
        else
        {
            _animator.SetBool(_moveParameter, false);
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = _walkSpeed;
    }


}