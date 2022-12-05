using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRun : CharComponents
{
    [SerializeField]
    private float _runSpeed = 12f;

    protected override void HandleInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopRun();
        }
    }

    private void Run()
    {
        cMovement.MoveSpeed = _runSpeed;
    }

    private void StopRun()
    {
        cMovement.ResetSpeed();
    }
}
    