using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState{

    protected GameObject player;

    protected CheckOnGround checkOnGround;
    protected Animator animator;
    protected Rigidbody rigidbody;
    protected Vector3 moveVec;
    protected PlayerStateMachine stateMachine;

    protected InputHandle inputHandle;
    protected InputKey input;

    private ChangeRotation changeRotation;

    public PlayerState()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        checkOnGround = new CheckOnGround();
        inputHandle = new InputHandle();
        changeRotation = new ChangeRotation();
        animator = player.GetComponent<Animator>();
        rigidbody = player.GetComponent<Rigidbody>();
        stateMachine = player.GetComponent<PlayerStateMachine>();
        moveVec = Vector3.zero;
        input = InputKey.NONE;
    }

    protected void ChangeDirection()
    {
        if(input != InputKey.JUMP)
            changeRotation.ChangeDirection((float)input, player);
    }

    public virtual void HandleInput() { }
    public virtual void PlayerEnter() { }
    public virtual void PlayerUpdate() { }
    public virtual void PlayerExit() { }
}
