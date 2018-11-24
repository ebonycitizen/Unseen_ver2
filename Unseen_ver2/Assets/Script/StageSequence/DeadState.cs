using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : StageSequenceState
{
    ParticleSystem deadEffect;
    Soul soul;

    public DeadState()
    {
        deadEffect = GameObject.Find("DeadEffect").GetComponent<ParticleSystem>();
        soul = GameObject.Find("Soul").GetComponent<Soul>();
    }

    public override void StageEnter()
    {
        playerStateMachine.enabled = false;
        foreach (SkinnedMeshRenderer mesh in player.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = false;
        player.GetComponentInChildren<Light>().enabled = false;

        deadEffect.transform.position = player.transform.position;
        deadEffect.Play();
        soul.Initialize(player.transform.position);
        deadTimes++;
    }
    public override void StageUpdate()
    {
        if (!soul.showSoul)
            stateMachine.currentState = StageSequenceMachine.State_StageSequence.PLAY;
    }
    public override void StageExit()
    {

    }
}
