using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterEffectState : StageSequenceState
{
    const float distanceDelta = 0.04f;
    const float angleDelta = 3f;
    const float cameraDelta = 1.5f;

    Vector3 farCamera;
    Vector3 nearCameraOffset;
    Vector3 nearCamera;

    Quaternion forwardAngle;
    Quaternion rightAngle;

    Animator startDoor;

    Image nextStageUI;
    Image clearUI;

    float zoomTimeCount;

    public EnterEffectState()
    {
        startDoor = GameObject.Find("startDoor").GetComponent<Animator>();

        farCamera = Camera.main.transform.position;
        nearCameraOffset = new Vector3(0.5f, 0.8f, -7.5f);
        nearCamera = startDoor.transform.position + nearCameraOffset;
        Camera.main.transform.position = nearCamera;

        forwardAngle = Quaternion.Euler(0, 90, 0);
        rightAngle = Quaternion.Euler(0, 0, 0);

        nextStageUI = GameObject.Find("NextStageUI").GetComponent<Image>();
        clearUI = GameObject.Find("ClearUI").GetComponent<Image>();
        GameObject.Find("OpenLight").GetComponent<Animator>().SetTrigger("ShowLight");
        zoomTimeCount = 0f;
    }

    public override void StageEnter()
    {
        nextStageUI.enabled = false;
        clearUI.enabled = false;

        zoomTimeCount = 0f;

        playerStateMachine.enabled = false;
        startDoor.SetTrigger("OpenDoor");
        

        animator.SetBool("Idle", false);
        animator.SetBool("Walk", true);
        player.transform.position = enterPosition;
        player.transform.rotation = forwardAngle;
    }
    public override void StageUpdate()
    {
        MovePlayer();
        RotatePlayer();
        MoveCamera();

        if (Camera.main.transform.position.z <= farCamera.z)
            stateMachine.currentState = StageSequenceMachine.State_StageSequence.PLAY;
    }
    public override void StageExit()
    {

    }

    private void MovePlayer()
    {
        if (player.transform.position.z <= startPosition.z)
            return;

        player.transform.position = Vector3.MoveTowards(player.transform.position, startPosition, distanceDelta);
    }
    private void RotatePlayer()
    {
        if (player.transform.position.z > startPosition.z)
            return;

        player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rightAngle, angleDelta);

        if(player.transform.rotation.eulerAngles.y == rightAngle.y)
            animator.SetBool("Walk", false);
    }
    private void MoveCamera()
    {
        if (player.transform.position.z > startPosition.z)
            return;

        Camera.main.transform.position = Vector3.Lerp(nearCamera, farCamera, zoomTimeCount);
        zoomTimeCount += Time.fixedDeltaTime / cameraDelta;
    }
}
