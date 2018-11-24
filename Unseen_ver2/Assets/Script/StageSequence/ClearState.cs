using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ClearState : StageSequenceState
{
    const float distanceDelta = 0.04f;
    const float angleDelta = 3f;
    const float lightSpeed = 0.5f;
    const float distanceDiff = 0.005f;

    Image nextStageUI;
    Image clearUI;

    ParticleSystem effect;

    Quaternion forwardAngle;
    Quaternion backwardAngle;

    Light clearLight;

    Animator goalDoor;

    StageDataBase stageDataBase;

    bool hasInput;

    public ClearState()
    {
        nextStageUI = GameObject.Find("NextStageUI").GetComponent<Image>();
        clearUI = GameObject.Find("ClearUI").GetComponent<Image>();
        effect = GameObject.Find("ClearEffect").GetComponent<ParticleSystem>();
        goalDoor = GameObject.Find("goalDoor").GetComponent<Animator>();
        clearLight = GameObject.Find("clearLight").GetComponent<Light>();

        stageDataBase = AssetDatabase.LoadAssetAtPath<StageDataBase>("Assets/Script/GameState/StageSelect/Stages/StageDataBase.asset");

        forwardAngle = Quaternion.Euler(0, 90, 0);
        backwardAngle = Quaternion.Euler(0, -90, 0);

        hasInput = false;
    }

    public override void StageEnter()
    {
        SaveData();
        nextStageUI.enabled = true;
        clearUI.enabled = true;
        effect.Play();

        animator.SetBool("Walk", true);
        playerStateMachine.enabled = false;
    }

    public override void StageUpdate()
    {
        MovePlayerBefore();
        RotatePlayerBefore();

        HandleInput();

        RotatePlayerAfter();
        MovePlayerAfter();
        ShowLight();

        if (hasInput && Mathf.Abs(player.transform.position.z - exitPosition.z) <= distanceDiff)
            stateMachine.currentState = StageSequenceMachine.State_StageSequence.ENTER;
    }

    public override void StageExit()
    {
        LoadNextScene();
    }

    //入力前のプレイヤーアニメーション
    private void MovePlayerBefore()
    {
        if (hasInput || Mathf.Abs(player.transform.position.x - goalPosition.x) <= distanceDiff)
            return;

        player.transform.position = Vector3.MoveTowards(player.transform.position, goalPosition, distanceDelta);
    }
    private void RotatePlayerBefore()
    {
        if (hasInput || Mathf.Abs(player.transform.position.x - goalPosition.x) > distanceDiff || 
            player.transform.rotation.eulerAngles.y == forwardAngle.y)
            return;

        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, forwardAngle, angleDelta);

        if (player.transform.rotation.eulerAngles.y == forwardAngle.eulerAngles.y)
        {
            animator.SetBool("Walk", false);
            animator.SetTrigger("Clear");
        }
    }

    private void HandleInput()
    {
        if (!hasInput && animator.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Clear"))
            return;

        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (key == KeyCode.Mouse0 || key == KeyCode.Mouse1 || key == KeyCode.Mouse2 ||
                key == KeyCode.Mouse3 || key == KeyCode.Mouse4 || key == KeyCode.Mouse5 || key == KeyCode.Mouse6)
                continue;
            if (Input.GetKeyDown(key))
            {
                animator.SetBool("Walk", true);
                goalDoor.SetTrigger("OpenDoor");
                hasInput = true;
            }
        }
    }

    //入力後のプレイヤーアニメーション
    private void RotatePlayerAfter()
    {
        if (!hasInput || player.transform.rotation.eulerAngles.y == backwardAngle.eulerAngles.y)
            return;

        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, backwardAngle, angleDelta);
    }
    private void MovePlayerAfter()
    {
        if (!hasInput || player.transform.rotation.eulerAngles.y != backwardAngle.eulerAngles.y)
            return;

        player.transform.position = Vector3.MoveTowards(player.transform.position, exitPosition, distanceDelta);
    }
    private void ShowLight()
    {
        if (!hasInput)
            return;

        clearLight.range += lightSpeed;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, deadTimes);
    }
    private void LoadNextScene()
    {
        Pauser.DestoryTarget();

        //次のステージ＃
        int nextStageNum;
        int.TryParse(SceneManager.GetActiveScene().name.Remove(0, 5), out nextStageNum);
        nextStageNum++;

        //クリアしたステージ数
        int clearedStageNum = 0;
        int stageNumMax = stageDataBase.GetStageList().Count;
        for (int i = 1; i <= stageNumMax; i++) 
        {
            if (PlayerPrefs.HasKey("Stage" + i.ToString()))
                clearedStageNum++;
        }

        //次のシーンへ
        if (clearedStageNum == stageNumMax)
            SceneManager.LoadScene("Ending");
        else
        {
            if(nextStageNum > stageNumMax)
                SceneManager.LoadScene("StageSelect");
            else
                SceneManager.LoadScene("Stage" + nextStageNum.ToString());
        }
    }
}
