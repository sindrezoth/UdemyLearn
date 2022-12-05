using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharDash : CharComponents
{
    [SerializeField]
    private float _dashDistance = 5f;
    [SerializeField]
    private float _dashDuration = 0.5f;

    private bool _isDashing = false;
    private float _dashTimer;
    private Vector2 _dashOrigin;
    private Vector2 _dashDestination;
    private Vector2 _newPosition;

    protected override void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        if(_isDashing)
        {
            if (_dashTimer < _dashDuration)
            {
                _newPosition = Vector2.Lerp(_dashOrigin, _dashDestination, _dashTimer / _dashDuration);
                cController.MovePosition(_newPosition);
                _dashTimer += Time.deltaTime;
            }
            else
            {
                StopDash();
            }
        }

    }

    private void Dash()
    {
        cController.NormalMovement = false;
        _isDashing = true;
        _dashTimer = 0f;
        _dashOrigin = transform.position;

        _dashDestination = transform.position + (Vector3)cController.CurrentMovement.normalized * _dashDistance;
    }

    private void StopDash()
    {
        _isDashing = false;
        cController.NormalMovement = true;
    }
}
