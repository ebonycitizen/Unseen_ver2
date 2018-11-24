using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour {
    int trapNum;
    GameObject[] trapObj;
    ITrap[] trap;

    void Start()
    {
        trapNum = GameObject.FindGameObjectsWithTag("Trap").Length;

        trapObj = new GameObject[trapNum];
        trapObj = GameObject.FindGameObjectsWithTag("Trap");

        trap = new ITrap[trapNum];
        for (int i = 0; i < trapNum; i++)
        {
            trap[i] = trapObj[i].GetComponent<ITrap>();
            trap[i].Initialize();
        }
    }

    public void Initialize()
    {
        for (int i = 0; i < trapNum; i++)
        {
            trap[i].Initialize();
        }
    }

    public void UpdateTrap () {
        for (int i = 0; i < trapNum; i++)
        {
            trap[i].UpdateTrap();
        }
    }

    public void Disable()
    {
        for (int i = 0; i < trapNum; i++)
        {
            trap[i].Disable();
        }
    }
}
