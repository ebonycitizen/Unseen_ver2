using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayState : StageSequenceState
{
    //player,ghost,trapの管理

    private PlayerCollision playerCollision;
    private GhostController ghostController;
    private TrapController trapController;
    private List<Vector3> posRecord;

    public PlayState()
    {
        posRecord = new List<Vector3>();
        ghostController = GameObject.Find("GhostController").GetComponent<GhostController>();
        trapController = GameObject.Find("TrapController").GetComponent<TrapController>();
        playerCollision = player.GetComponent<PlayerCollision>();

        //プレイヤーがトラップに当たったらステートをDEADにするイベント
        playerCollision.OnDead += delegate (object sender, EventArgs e)
        {
            stateMachine.currentState = StageSequenceMachine.State_StageSequence.DEAD;
        };
        playerCollision.OnReachGoal += delegate (object sender, EventArgs e)
        {
            stateMachine.currentState = StageSequenceMachine.State_StageSequence.EXIT;
        };
    }

    public override void StageEnter()
    {
        //プレイヤーの初期化
        foreach (SkinnedMeshRenderer mesh in player.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = true;
        player.GetComponentInChildren<Light>().enabled = true;
        playerStateMachine.enabled = true;
        player.transform.position = startPosition;
        animator.SetBool("Idle", true);

        //ゴーストに前回の位置記録を渡す
        Vector3[] tmp = new Vector3[posRecord.Count];
        for (int i = 0; i < tmp.Length; i++)
            tmp[i] = posRecord[i];
        ghostController.Initialize(tmp, deadTimes);
        posRecord.Clear();

        //reset trap
        trapController.Initialize();
    }
    public override void StageUpdate()
    {
        ShowPause();
        RecordPos();
        ghostController.UpdateGhost(deadTimes);
        //move trap
        trapController.UpdateTrap();
    }
    public override void StageExit()
    {
        ghostController.Disable(deadTimes);
        trapController.Disable();
    }

    private void RecordPos()
    {
        //動いているときだけ記録する
        if (posRecord.Count == 0 || player.transform.position != posRecord[posRecord.Count - 1])
        {
            posRecord.Add(player.transform.position);
        }
    }
    private void ShowPause()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Pauser.Pause();
    }
}