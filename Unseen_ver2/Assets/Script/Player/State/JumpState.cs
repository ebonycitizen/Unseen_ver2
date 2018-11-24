using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerState
{
    private float jumpPower = 5.2f;

    public override void HandleInput()
    {
        checkOnGround.CheckisGrounded(player);
        input = inputHandle.HandleInput();

        if (input == InputKey.WALK_RIGHT || input == InputKey.WALK_LEFT)
            stateMachine.currentState = PlayerStateMachine.State_Player.WALK;

        checkOnGround.CheckisGrounded(player);
        if (checkOnGround.isGround)
            stateMachine.currentState = PlayerStateMachine.State_Player.IDLE;
    }
    public override void PlayerEnter()
    {
        animator.SetTrigger("Jump");
    }
    public override void PlayerUpdate()
    {
        Jump();
        HandleInput();
    }
    public override void PlayerExit()
    {

    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
    }
}
