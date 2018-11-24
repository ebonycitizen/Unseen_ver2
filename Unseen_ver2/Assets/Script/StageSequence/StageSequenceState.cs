using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSequenceState {

    protected GameObject player;
    protected Animator animator;
    protected StageSequenceMachine stateMachine;
    protected PlayerStateMachine playerStateMachine;

    protected Vector3 enterPosition;
    protected Vector3 startPosition;
    protected Vector3 goalPosition;
    protected Vector3 exitPosition;

    protected static int deadTimes;

    public StageSequenceState()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.GetComponent<Animator>();
        stateMachine = GameObject.Find("StageStateMachine").GetComponent<StageSequenceMachine>();
        playerStateMachine = player.GetComponent<PlayerStateMachine>();

        enterPosition = GameObject.Find("EnterPosition").transform.position;
        startPosition = GameObject.Find("StartPosition").transform.position;
        goalPosition = GameObject.Find("GoalPosition").transform.position;
        exitPosition = GameObject.Find("ExitPosition").transform.position;

        //y軸はプレイヤーに合わせる
        enterPosition.y = player.transform.position.y;
        startPosition.y = player.transform.position.y;
        startPosition.y = player.transform.position.y;

        deadTimes = 0;
    }

    public virtual void StageEnter() { }
    public virtual void StageUpdate() { }
    public virtual void StageExit() { }
}
