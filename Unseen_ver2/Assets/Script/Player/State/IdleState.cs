using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void HandleInput()
    {
        checkOnGround.CheckisGrounded(player);
        input = inputHandle.HandleInput();

        if (input == InputKey.WALK_RIGHT || input == InputKey.WALK_LEFT)
            stateMachine.currentState = PlayerStateMachine.State_Player.WALK;

        if (checkOnGround.isGround && input == InputKey.JUMP)
            stateMachine.currentState = PlayerStateMachine.State_Player.JUMP;
    }
    public override void PlayerEnter()
    {
        animator.SetBool("Idle", true);
    }
    public override void PlayerUpdate()
    {
        HandleInput();
        ChangeDirection();
    }
    public override void PlayerExit()
    {
        animator.SetBool("Idle", false);
    }
}
