using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharFlip : CharComponents
{
    public enum FlipMode
    {
        MovementDirection,
        WeaponDirection
    }

    [SerializeField]
    private FlipMode _flipMode = FlipMode.MovementDirection;
    [SerializeField]
    private float _treshold = 0.1f;

    protected override void HandleAbility()
    {
        base.HandleAbility();

        if(_flipMode == FlipMode.MovementDirection)
        {
            FlipToMoveDirection();
        }
        else
        {
            FlipToWeaponDirection();
        }
    }

    private void FlipToMoveDirection()
    {
        if(cController.CurrentMovement.normalized.magnitude > _treshold)
        {
            if(cController.CurrentMovement.normalized.x > 0)
            {
                FaceDirection(1);
            }
            else
            {
                FaceDirection(-1);
            }
        }

    }

    private void FlipToWeaponDirection()
    {

    }

    private void FaceDirection(int newDirection)
    {
        Vector3 locSc = transform.localScale;

        if (newDirection == 1)
        {
            locSc.x = Mathf.Abs(locSc.x);
        }
        else if (newDirection == -1)
        {
            locSc.x = -Mathf.Abs(locSc.x);
        }

        transform.localScale = locSc;
    }

}