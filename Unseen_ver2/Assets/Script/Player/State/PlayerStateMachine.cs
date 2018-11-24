using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum State_Player
    {
        IDLE,
        WALK,
        JUMP,
        NONE,
    }

    private StateMachine<State_Player> stateMachine = new StateMachine<State_Player>();
    private State_Player oldState;

    [HideInInspector]
    public State_Player currentState;

    private IdleState idleState;
    private WalkState walkState;
    private JumpState jumpState;

    private InputKey input;

    // Use this for initialization
    void Start()
    {
        idleState = new IdleState();
        walkState = new WalkState();
        jumpState = new JumpState();

        currentState = State_Player.IDLE;
        oldState = State_Player.NONE;
        
        //add
        stateMachine.Add(State_Player.IDLE, idleState.PlayerEnter, idleState.PlayerUpdate, idleState.PlayerExit);
        stateMachine.Add(State_Player.WALK, walkState.PlayerEnter, walkState.PlayerUpdate, walkState.PlayerExit);
        stateMachine.Add(State_Player.JUMP, jumpState.PlayerEnter, jumpState.PlayerUpdate, jumpState.PlayerExit);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != oldState)
            stateMachine.Change(currentState);
        oldState = currentState;
        stateMachine.Update();
    }
}
