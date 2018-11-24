using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    private const float speed = 3.0f;
    InputKey oldInput;

    public override void HandleInput()
    {
        checkOnGround.CheckisGrounded(player);
        oldInput = input;
        input = inputHandle.HandleInput();

        if (input == InputKey.RELEASE)
            stateMachine.currentState = PlayerStateMachine.State_Player.IDLE;

        if (checkOnGround.isGround && input == InputKey.JUMP)
            stateMachine.currentState = PlayerStateMachine.State_Player.JUMP;
    }
    public override void PlayerEnter()
    {
        animator.SetBool("Walk", true);
    }
    public override void PlayerUpdate()
    {
        HandleInput();
        ChangeDirection();
        Move();
    }
    public override void PlayerExit()
    {
        animator.SetBool("Walk", false);
        MoveJump();
    }

    private void Move()
    {
        if (stateMachine.currentState != PlayerStateMachine.State_Player.WALK|| input == InputKey.JUMP)
            return;

        Vector3 velocity = new Vector3((float)input, 0, 0);

        velocity *= speed;
        rigidbody.position += velocity * Time.fixedDeltaTime;
    }

    private void MoveJump()
    {
        //ジャンプ前の移動
        Vector3 velocity = new Vector3((float)oldInput, 0, 0);

        velocity *= speed;
        rigidbody.position += velocity * Time.fixedDeltaTime;
    }
}
