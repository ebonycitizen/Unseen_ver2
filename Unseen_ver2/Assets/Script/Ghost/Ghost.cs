using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {
    const float maxIntensity = 2f;
    const float turnOffSpeed = 0.008f;
    const float lightDis = 2f;
    const float diffOffset = 0.05f;

    enum State
    {
        IDLE, WALK, JUMP, NONE,
    }

    State curState;
    State oldState;

    Vector3[] position;
    Vector3 oldLightPos;
    ChangeRotation changeRotation;
    Animator animator;
    ParticleSystem dispearEffect;
    GameObject ghostLight;

    int nowIndex;
    float heightOffset;

	// Use this for initialization
	void Awake () {
        changeRotation = new ChangeRotation();
        animator = this.GetComponent<Animator>();
        oldState = State.JUMP;
        curState = State.JUMP;
        nowIndex = 0;
        dispearEffect = GameObject.Find("DisappearEffect").GetComponent<ParticleSystem>();
        ghostLight = GameObject.Find("GhostController").GetComponent<GhostController>().lightPrefab;
        heightOffset = GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    public void Initialize(Vector3[] posRecord)
    {
        position = posRecord;
        oldLightPos = position[0];
    }

    public void Reset()
    {
        oldState = State.IDLE;
        curState = State.IDLE;

        nowIndex = 0;

        EnableGhost();
        DestroyLight();
    }

    public void Disable()
    {
        foreach (SkinnedMeshRenderer mesh in this.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = false;
    }

    public void UpdateGhost()
    {
        if (position.Length <= 0)
            return;

        if(nowIndex <= position.Length)
            nowIndex++;

        Move();
        Rotate();
        ChangeState();
        ChangeAnimation();

        //死亡位置着いた後ゴースト消す
        if (nowIndex != position.Length)
            return;
        dispearEffect.transform.position = position[nowIndex - 1];
        dispearEffect.Play();
        Disable();
    }

    public void UpdateLight()
    {
        if (position.Length <= 0)
            return;

        CreateLight();

        //死亡位置着いた後ライト消す
        if (nowIndex < position.Length)
            return;
        TurnOffLight();
    }

    private void EnableGhost()
    {
        foreach (SkinnedMeshRenderer mesh in this.GetComponentsInChildren<SkinnedMeshRenderer>())
            mesh.enabled = true;
    }
    private void DestroyLight()
    {
        this.GetComponentInChildren<Light>().intensity = maxIntensity;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GhostLight"))
            Destroy(obj);
    }

    private void ChangeState()
    {
        if (nowIndex == 0 || nowIndex >= position.Length)
            return;

        Vector3 diff = position[nowIndex] - position[nowIndex - 1];

        if (diff.y >= diffOffset || diff.y <= -diffOffset)
        {
            curState = State.JUMP;
            return;
        }
        if (diff.x != 0.00)
        {
            curState = State.WALK;
            return;
        }
        curState = State.IDLE;
    }
    private void ChangeAnimation()
    {
        if (oldState == curState || nowIndex == position.Length)
            return;

        switch (curState)
        {
            case State.IDLE:
                animator.SetBool("Idle", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Jump", false);
                break;
            case State.WALK:
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", true);
                animator.SetBool("Jump", false);
                break;
            case State.JUMP:
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", false);
                animator.SetBool("Jump", true);
                break;
            default:
                break;
        }
        oldState = curState;
    }
    private void Move()
    {
        if (nowIndex == 0 || nowIndex >= position.Length)
            return;
        this.transform.position = position[nowIndex];
    }
    private void Rotate()
    {
        if (nowIndex == 0 || nowIndex >= position.Length)
            return;

        int direction = 0;
        if (position[nowIndex].x - position[nowIndex - 1].x > diffOffset)
            direction = 1;//right
        if (position[nowIndex].x - position[nowIndex - 1].x < -diffOffset)
            direction = -1;//left
        changeRotation.ChangeDirection(direction, this.gameObject);
    }

    private void CreateLight()
    {
        //道を照らす光を作る
        if (nowIndex == 0 || nowIndex >= position.Length)
            return;

        if (Mathf.Abs(position[nowIndex].x - oldLightPos.x) > lightDis)
        {
            Vector3 pos = new Vector3(position[nowIndex].x, position[nowIndex].y + heightOffset, position[nowIndex].z);
            Instantiate(ghostLight, pos, Quaternion.identity);
            oldLightPos = position[nowIndex];
        }
    }
    private void TurnOffLight()
    {
        //道のライトを徐々に消す
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("GhostLight"))
        {
            Light light = obj.GetComponent<Light>();
            
            if (light.intensity <= 0)
                continue;
            light.intensity -= turnOffSpeed;
        }

        Light ghostLight = this.GetComponentInChildren<Light>();
        if (ghostLight.intensity <= 0)
            return;
        ghostLight.intensity -= turnOffSpeed;
    }
}
