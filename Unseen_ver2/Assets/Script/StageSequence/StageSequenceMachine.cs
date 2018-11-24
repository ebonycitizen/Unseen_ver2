using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSequenceMachine : MonoBehaviour {

    public enum State_StageSequence
    {
        START,
        ENTER,
        PLAY,
        DEAD,
        EXIT,
    }

    private StateMachine<State_StageSequence> stateMachine = new StateMachine<State_StageSequence>();
    private State_StageSequence oldState;

    [HideInInspector]
    public State_StageSequence currentState;

    private EnterEffectState enterEffectState;
    private PlayState playState;
    private DeadState deadState;
    private ClearState clearState;

    // Use this for initialization
    void Start () {
        enterEffectState = new EnterEffectState();
        playState = new PlayState();
        deadState = new DeadState();
        clearState = new ClearState();

        currentState = State_StageSequence.ENTER;
        //oldState = currentState;
        oldState = State_StageSequence.START;

        stateMachine.Add(State_StageSequence.ENTER, enterEffectState.StageEnter, enterEffectState.StageUpdate, enterEffectState.StageExit);
        stateMachine.Add(State_StageSequence.PLAY, playState.StageEnter, playState.StageUpdate, playState.StageExit);
        stateMachine.Add(State_StageSequence.DEAD, deadState.StageEnter, deadState.StageUpdate, deadState.StageExit);
        stateMachine.Add(State_StageSequence.EXIT, clearState.StageEnter, clearState.StageUpdate, clearState.StageExit);
    }

    // Update is called once per frame
    void Update () {
        if (currentState != oldState)
            stateMachine.Change(currentState);
        oldState = currentState;
        stateMachine.Update();
    }
}
