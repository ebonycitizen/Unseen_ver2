using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour{
    public GameObject ghostPrefab;
    public GameObject lightPrefab;
    public int maxGhostNum = 3;

    Ghost[] ghost;
    Transform startPosition;

	void Start() {
        ghost = new Ghost[maxGhostNum];
        startPosition = GameObject.Find("GhostController").transform;
	}

    public void Initialize(Vector3[] posRecord, int deadTimes)
    {
        if (deadTimes <= 0)
            return;

        int n = (deadTimes - 1) % maxGhostNum;
        Instantiate(deadTimes, n);

        ghost[n] = GameObject.Find("Ghost" + n).GetComponent<Ghost>();
        ghost[n].Initialize(posRecord);

        for (int i = 0; i < maxGhostNum; i++)
        {
            if (ghost[i] == null)
                continue;
            ghost[i].Reset();
        }
    }

	public void UpdateGhost (int deadTimes)
    {
        if (deadTimes <= 0)
            return;

        for (int i = 0; i < maxGhostNum; i++)
        {
            if (ghost[i] == null)
                continue;
            ghost[i].UpdateGhost();
            ghost[i].UpdateLight();
        }
    }

    public void Disable(int deadTimes)
    {
        if (deadTimes <= 0)
            return;

        for (int i = 0; i < maxGhostNum; i++)
        {
            if (ghost[i] == null)
                continue;
            ghost[i].Disable();
        }
    }

    //create ghost game object
    private void Instantiate(int deadTimes, int n)
    {
        if (deadTimes <= 0 || deadTimes > maxGhostNum)
            return;

        GameObject tmp = (GameObject)Instantiate(ghostPrefab, startPosition);
        tmp.name = ghostPrefab.name + n.ToString();
    }
}
